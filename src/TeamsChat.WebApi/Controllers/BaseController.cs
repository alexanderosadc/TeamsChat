using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.Data.UnitOfWork;

namespace TeamsChat.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _database;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
    }
}
