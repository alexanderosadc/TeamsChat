using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.SSMS.UnitOfWork;

namespace TeamsChat.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ISSMSUnitOfWork _database;
        protected readonly IMapper _mapper;

        public BaseController(ISSMSUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
    }
}
