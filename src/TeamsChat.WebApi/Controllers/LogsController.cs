using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.MongoDbService.UnitOfWork;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogsRepository _productRepository;
        private readonly IMongoDbUnitOfWork _uow;

        public LogsController(ILogsRepository productRepository, IMongoDbUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logs>>> Get()
        {
            var logs = await _productRepository.GetAll();

            return Ok(logs);
        }
        [HttpPost]
        public ActionResult<Logs> Insert([FromBody] Logs log)
        {

            _productRepository.Insert(log);

            return Ok();
        }
    }
}
