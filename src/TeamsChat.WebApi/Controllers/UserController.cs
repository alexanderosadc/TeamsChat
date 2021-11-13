using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    public class UserController : BaseController
    {
        ISSMSUnitOfWork _database;
        public UserController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager) 
        {
            _database = databaseFactory.GetDb<ISSMSUnitOfWork>();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> FindUserByName([FromQuery] string firstName, string lastName)
        {
            var userDb = _database.GetRepository<User>()
                .SingleOrDefault(
                    filter: user => (firstName == null || user.FirstName.ToLower().Contains(firstName))
                        && (lastName == null || user.LastName.ToLower().Contains(lastName)));

            if (userDb == null)
            {
                await _controllerManager.CreateLog(HttpContext, 204);
                return NoContent();
            }

            var userDto = _mapper.Map<UserDTO>(userDb);

            await _controllerManager.CreateLog(HttpContext, 200);
            return Ok(userDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> LoginUser(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                return Forbid();

            var userDb = _database.GetRepository<User>()
                .SingleOrDefault(
                    filter: user => user.Email == email && user.Password == password,
                    include: user => user
                        .Include(user => user.MessageGroups));

            if (userDb == null)
            {
                await _controllerManager.CreateLog(HttpContext, 203);
                return NoContent();
            }

            var userDto = _mapper.Map<UserDTO>(userDb);

            await _controllerManager.CreateLog(HttpContext, 200);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] UserDTO userDTO)
        {
            var userToDb = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = userDTO.Password
            };

            var user = _database.GetRepository<User>().Insert(userToDb);
            _database.SaveChanges();

            if (user.ID == 0)
            {
                await _controllerManager.CreateLog(HttpContext, 500);
                return StatusCode(500);
            }

            await _controllerManager.CreateLog(HttpContext, 201);
            return StatusCode(201);
        }
    }
}
