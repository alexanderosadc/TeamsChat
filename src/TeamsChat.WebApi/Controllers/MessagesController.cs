using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.WebApi.DTO;
using System;
using TeamsChat.WebApi.Common;
using System.Linq;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : BaseController
    {
        public MessagesController(ISSMSUnitOfWork database, IMapper mapper, IControllerManager controllerManager) : base(database, mapper, controllerManager) { }

        [HttpGet]
        public ActionResult<IEnumerable<MessageDTO>> GetMessages()
        {
            var messageDTO = _database.GetRepository<Message>().GetList(
                selector: message => _mapper.Map<MessageDTO>(message),
                include: message => message
                    .Include(message => message.MessageGroup)
                    .Include(message => message.User));

            if (messageDTO.Count() == 0)
            {
                _controllerManager.CreateLog(HttpContext, 204);
                return NoContent();
            }

            _controllerManager.CreateLog(HttpContext, 200);
            return Ok(messageDTO);
        }

        [HttpGet("groupId={groupId}")]
        public ActionResult<IEnumerable<MessageDTO>> GetMessagesByGroupId(int groupId)
        {
            var messageDTO = _database.GetRepository<Message>().GetList(
                selector: message => _mapper.Map<MessageDTO>(message),
                filter: message => message.MessageGroup.ID == groupId,
                include: message => message
                    .Include(message => message.MessageGroup)
                    .Include(message => message.User));

            if (messageDTO.Count() == 0)
            {
                _controllerManager.CreateLog(HttpContext, 204);
                return NoContent();
            }

            _controllerManager.CreateLog(HttpContext, 200);
            return Ok(messageDTO);
        }

        [HttpPost]
        public ActionResult<MessageDTO> PostMessage([FromBody] MessageDTO messageDTO)
        {
            var messageGroupDb = _database.GetRepository<MessageGroup>().SingleOrDefault(
                filter: group => group.ID == messageDTO.MessageGroup.ID);

            var userDb = _database.GetRepository<User>().SingleOrDefault(
                filter: user => user.ID == messageDTO.User.ID);

            var messageToDb = new Message
            {
                Text = messageDTO.Text,
                CreatedAt = DateTime.Now,
                MessageGroup = messageGroupDb,
                User = userDb
            };

            _database.GetRepository<Message>().Insert(messageToDb);
            _database.SaveChanges();

            if (messageToDb.ID == 0)
            {
                _controllerManager.CreateLog(HttpContext, 500);
                return StatusCode(500);
            }

            _controllerManager.CreateLog(HttpContext, 201);
            return StatusCode(201);
        }
    }
}
