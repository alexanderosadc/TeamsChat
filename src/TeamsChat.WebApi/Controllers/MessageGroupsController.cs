using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.WebApi.DTO;
using TeamsChat.WebApi.Common;
using System.Threading.Tasks;
using TeamsChat.DatabaseInterface;
using TeamsChat.WebApi.DbCommunicators;
using TeamsChat.TimeoutService;
using TeamsChat.TimeoutService.Models;
using System.Net;
using System.Collections.Generic;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageGroupsController : BaseController
    {
        private int _timeout = 5;
        private MessageGroupsCommunicator _messageGroupsCommunicator;
        public MessageGroupsController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager) 
        {
            _messageGroupsCommunicator = new MessageGroupsCommunicator(databaseFactory, mapper, controllerManager);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageGroupDTO>>> GetGroups()
        {
            var result = await TimeoutManager.TimeoutValidator(_messageGroupsCommunicator.GetGroups, HttpContext, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.NoContent)
                return StatusCode(204);

            return Ok(result.Output.Data);
        }

        [HttpPost]
        public async Task<ActionResult<MessageGroupDTO>> PostGroup([FromBody] MessageGroupDTO groupDTO)
        {
            TimeoutParameters<MessageGroupDTO> parameters = new TimeoutParameters<MessageGroupDTO> { Container = groupDTO, HttpContext = HttpContext };
            var result = await TimeoutManager.TimeoutValidator(_messageGroupsCommunicator.PostGroup, parameters, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.InternalServerError)
                return StatusCode(500);

            return StatusCode(201);
        }
    }
}
