using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.DataObjects.MSSQLModels;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageGroupController : BaseController
    {
        public MessageGroupController(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

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
