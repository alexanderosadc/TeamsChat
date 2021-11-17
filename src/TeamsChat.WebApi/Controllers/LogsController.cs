using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsChat.WebApi.DTO;
using TeamsChat.WebApi.Common;
using Microsoft.AspNetCore.Routing;
using TeamsChat.DatabaseInterface;
using TeamsChat.WebApi.DbCommunicators;
using TeamsChat.TimeoutService;
using System.Net;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : BaseController
    {
        private LogsCommunicator _logsCommunicator;
        private int _timeout = 5;
        public LogsController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager)
        {
            _logsCommunicator = new LogsCommunicator(databaseFactory, mapper, controllerManager);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDTO>>> Get()
        {
            var result = await TimeoutManager.TimeoutValidator(_logsCommunicator.GetAllLogs, _timeout);

            if (result.StatusCode == HttpStatusCode.RequestTimeout)
                return StatusCode(408);

            if (result.Output.StatusCode == HttpStatusCode.NoContent)
                return StatusCode(204);

            return Ok(result.Output.Data);
        }

        // mock endpoint 
        //[HttpGet("getOne")]
        //public ActionResult<LogDTO> GetOne(ObjectId id)
        //{
        //    var logDb = _logsRepository.GetFiltered(
        //        filterExpression: log => log.Id == id);

        //    var log = _mapper.Map<LogDTO>(logDb.First());

        //    return Ok(log);
        //}
    }
}
