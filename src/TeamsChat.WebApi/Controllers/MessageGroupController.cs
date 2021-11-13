using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.WebApi.DTO;
using TeamsChat.WebApi.Common;
using System.Threading.Tasks;
using TeamsChat.DatabaseInterface;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageGroupController : BaseController
    {
        ISSMSUnitOfWork _database;

        public MessageGroupController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager) 
        {
            _database = databaseFactory.GetDb<ISSMSUnitOfWork>();
        }

        [HttpPost]
        public async Task<ActionResult<MessageGroupDTO>> PostGroup([FromBody] MessageGroupDTO groupDTO)
        {
            var users = _database.GetRepository<User>().GetList(
                selector: user => user,
                filter: user => groupDTO.Users.Select(userDto => userDto.ID).Contains(user.ID)).ToList();

            var groupToDb = new MessageGroup
            {
                Title = groupDTO.Title,
                Users = users
            };

            _database.GetRepository<MessageGroup>().Insert(groupToDb);
            _database.SaveChanges();

            if (groupToDb.ID == 0)
            {
                await _controllerManager.CreateLog(HttpContext, 500);
                return StatusCode(500);
            }

            await _controllerManager.CreateLog(HttpContext, 201);
            return StatusCode(201);
        }
    }
}
