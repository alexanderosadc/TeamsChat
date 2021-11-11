using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.MongoDbService.UnitOfWork;
using TeamsChat.WebApi.DTO;
using System.Linq;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : BaseController
    {
        public LogsController(ISSMSUnitOfWork database, IMapper mapper, ILogsRepository logsRepository) : base(database, mapper, logsRepository) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDTO>>> Get()
        {
            var logsDb = await _logsRepository.GetAll();

            IList<LogDTO> logs = new List<LogDTO>();

            foreach (var log in logsDb)
            {
                logs.Add(_mapper.Map<LogDTO>(log));
            }

            return Ok(logs);
        }

        [HttpPost]
        public ActionResult<Logs> Insert([FromBody] Logs log)
        {
            _logsRepository.Insert(log);

            return Ok();
        }
    }
}
