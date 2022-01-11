using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TeamsChat.WebApi.DTO;
using TeamsChat.WebApi.Common;
using System.Threading.Tasks;
using TeamsChat.DatabaseInterface;
using TeamsChat.TimeoutService.Models;
using TeamsChat.TimeoutService;
using TeamsChat.WebApi.DbCommunicators;
using System.Net;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        private UsersCommunicator _usersCommunicator;
        private int _timeout = 5;

        public UsersController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager)
        {
            _usersCommunicator = new UsersCommunicator(databaseFactory, mapper, controllerManager);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserByName([FromQuery] string firstName, string lastName)
        {

            TimeoutParameters<UserDTO> parameters = new TimeoutParameters<UserDTO> { Container = new UserDTO { FirstName = firstName, LastName = lastName }, HttpContext = HttpContext };
            var result = await TimeoutManager.TimeoutValidator(_usersCommunicator.GetUserByName, parameters, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.NoContent)
                return StatusCode(204);

            return Ok(result.Output.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> LoginUser(string email, string password)
        {
            TimeoutParameters<UserDTO> parameters = new TimeoutParameters<UserDTO> { Container = new UserDTO { Email = email, Password = password }, HttpContext = HttpContext };
            var result = await TimeoutManager.TimeoutValidator(_usersCommunicator.LoginUser, parameters, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.Forbidden)
                return StatusCode(403);

            if (result.Output.StatusCode == HttpStatusCode.NoContent)
                return StatusCode(204);

            return Ok(result.Output.Data);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser([FromBody] UserDTO userDTO)
        {
            TimeoutParameters<UserDTO> parameters = new TimeoutParameters<UserDTO> { Container = userDTO, HttpContext = HttpContext };
            var result = await TimeoutManager.TimeoutValidator(_usersCommunicator.PostUser, parameters, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.Forbidden)
                return StatusCode(403);

            if (result.Output.StatusCode == HttpStatusCode.InternalServerError)
                return StatusCode(500);

            return StatusCode(201);
        }
    }
}