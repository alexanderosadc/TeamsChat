using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.WebApi.DTO;
using System;
using TeamsChat.MongoDbService.ModelRepositories;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : BaseController
    {
        public MessagesController(ISSMSUnitOfWork database, IMapper mapper, ILogsRepository logsRepository) : base(database, mapper, logsRepository) { }

        [HttpGet]
        public ActionResult<IEnumerable<MessageDTO>> GetMessages()
        {
            var data = _database.GetRepository<Message>().GetList(
                selector: message => _mapper.Map<MessageDTO>(message),
                include: message => message
                    .Include(message => message.MessageGroup)
                    .Include(message => message.User));

            return Ok(data);
        }

        [HttpGet("groupId={groupId}")]
        public ActionResult<IEnumerable<MessageDTO>> GetMessagesByGroupId(int groupId)
        {
            var data = _database.GetRepository<Message>().GetList(
                selector: message => _mapper.Map<MessageDTO>(message),
                filter: message => message.MessageGroup.ID == groupId,
                include: message => message
                    .Include(message => message.MessageGroup)
                    .Include(message => message.User));

            return Ok(data);
        }

        [HttpPost]
        public ActionResult<MessageDTO> PostMessage([FromBody] MessageDTO messageDTO)
        {
            var messageGroupDb = _database.GetRepository<MessageGroup>().SingleOrDefault(
                filter: group => group.ID == messageDTO.MessageGroup.ID);

            var userDb = _database.GetRepository<User>().SingleOrDefault(
                filter: user => user.ID == messageDTO.User.ID);

            var message = new Message
            {
                Text = messageDTO.Text,
                CreatedAt = DateTime.Now,
                MessageGroup = messageGroupDb,
                User = userDb
            };

            _database.GetRepository<Message>().Insert(message);
            _database.SaveChanges();

            return Ok();
        }
    }
}
