using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TeamsChat.WebApi.DTO;
using TeamsChat.WebApi.Common;
using System.Threading.Tasks;
using TeamsChat.DatabaseInterface;
using TeamsChat.WebApi.DbCommunicators;
using TeamsChat.TimeoutService;
using System.Net;
using TeamsChat.TimeoutService.Models;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : BaseController
    {
        private MessagesCommunicator _messagesCommunicator;
        private int _timeout = 5;
        public MessagesController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager)
        {
            _messagesCommunicator = new MessagesCommunicator(databaseFactory, mapper, controllerManager);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessages()
        {
            var result = await TimeoutManager.TimeoutValidator(_messagesCommunicator.GetMessages, HttpContext, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.NoContent)
                return StatusCode(204);

            return Ok(result.Output.Data);
        }

        [HttpGet("groupId={groupId}")]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessagesByGroupId(int groupId)
        {
            TimeoutParameters<int> parameters = new TimeoutParameters<int> { Container = groupId, HttpContext = HttpContext };
            var result = await TimeoutManager.TimeoutValidator(_messagesCommunicator.GetMessagesByGroupId, parameters, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.NoContent)
                return StatusCode(204);

            return Ok(result.Output.Data);
        }

        [HttpPost]
        public async Task<ActionResult<MessageDTO>> PostMessage([FromBody] MessageDTO messageDTO)
        {
            TimeoutParameters<MessageDTO> parameters = new TimeoutParameters<MessageDTO> { Container = messageDTO, HttpContext = HttpContext };
            var result = await TimeoutManager.TimeoutValidator(_messagesCommunicator.PostMessage, parameters, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.InternalServerError)
                return StatusCode(500);

            return StatusCode(201);
        }
    }
}
