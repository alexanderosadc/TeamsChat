using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.WebApi.DTO;
using System.Linq;
using MongoDB.Bson;
using TeamsChat.WebApi.Common;
using Microsoft.AspNetCore.Routing;
using TeamsChat.DatabaseInterface;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : BaseController
    {
        private ILogsRepository _logsRepository;
        public LogsController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager) : base(databaseFactory, mapper, controllerManager)
        {
            _logsRepository = databaseFactory.GetDb<ILogsRepository>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDTO>>> Get()
        {
            var logsDb = await _logsRepository.GetAll();

            if (logsDb.Count() == 0)
                return StatusCode(204);

            IList<LogDTO> logs = new List<LogDTO>();

            foreach (var log in logsDb)
            {
                logs.Add(_mapper.Map<LogDTO>(log));
            }

            return Ok(logs);
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
