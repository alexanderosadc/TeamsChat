using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.WebApi.DTO;
using TeamsChat.MongoDbService.ModelRepositories;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageGroupController : BaseController
    {
        public MessageGroupController(ISSMSUnitOfWork database, IMapper mapper, ILogsRepository logsRepository) : base(database, mapper, logsRepository) { }

        [HttpPost]
        public ActionResult<MessageGroupDTO> PostGroup([FromBody] MessageGroupDTO groupDTO)
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

            return Ok();
        }
    }
}
