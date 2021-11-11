using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.WebApi.Services;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly LogService _logService;
        public LogsController(LogService bookService)
        {
            _logService = bookService;
        }
        //public LogsController(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

        [HttpGet]
        public ActionResult<List<Logs>> Get() =>
            _logService.Get();

    }
}
