using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.Data.UnitOfWork;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : BaseController
    {
        public LogsController(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }
    }
}
