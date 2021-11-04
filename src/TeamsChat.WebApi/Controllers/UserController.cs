using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.DataObjects.MSSQLModels;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

        [HttpGet("search")]
        public ActionResult<IEnumerable<UserDTO>> FindUserByName([FromQuery] string firstName, string lastName)
        {
            var userDb = _database.GetRepository<User>()
                .SingleOrDefault(
                    filter: user => (firstName == null || user.FirstName.ToLower().Contains(firstName))
                        && (lastName == null || user.LastName.ToLower().Contains(lastName)));

            if (userDb == null)
                return NotFound();

            var userDto = _mapper.Map<UserDTO>(userDb);

            return Ok(userDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> LoginUser(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                return Forbid();

            var userDb = _database.GetRepository<User>()
                .SingleOrDefault(
                    filter: user => user.Email == email && user.Password == password,
                    include: user => user
                        .Include(user => user.MessageGroups));

            if (userDb == null)
                return NotFound();

            var userDto = _mapper.Map<UserDTO>(userDb);

            return Ok(userDto);
        }

        [HttpPost]
        public ActionResult<UserDTO> PostUser([FromBody] UserDTO userDTO)
        {
            var userToDb = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = userDTO.Password
            };

            _database.GetRepository<User>().Insert(userToDb);
            _database.SaveChanges();

            return Ok();
        }
    }
}
