using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.WebApi.DTO;
using System.Linq;
using MongoDB.Bson;
using TeamsChat.WebApi.Common;
using Microsoft.AspNetCore.Routing;
using TeamsChat.DatabaseInterface;
using TeamsChat.WebApi.DbCommunicators;
using TeamsChat.TimeoutService;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : BaseController
    {
        private ILogsRepository _logsRepository;
        private LogsCommunicator _logsCommunicator;
        public LogsController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager)
        {
            _logsCommunicator = new LogsCommunicator(databaseFactory, mapper, controllerManager);
            _logsRepository = databaseFactory.GetDb<ILogsRepository>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDTO>>> Get()
        {
            var data = await TimeoutManager.TimeoutValidator(_logsCommunicator.GetAllLogs, 3);

            if (data.HasTimeOut == true)
                return StatusCode(408);
            
            if (data.Output.Count() == 0)
                return StatusCode(204);

            return Ok(data.Output);
        }

        // mock endpoint 
        [HttpGet("getOne")]
        public async Task<ActionResult<LogDTO>> GetOne(ObjectId id)
        {
            var logDb = await _logsRepository.GetFiltered(
                filterExpression: log => log.Id == id);

            var log = _mapper.Map<LogDTO>(logDb.First());

            return Ok(log);
        }
    }
}
