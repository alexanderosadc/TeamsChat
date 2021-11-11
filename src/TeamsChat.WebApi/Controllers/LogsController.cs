using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.DataObjects.MongoDbModels;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        //public LogsController(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

    }
}
