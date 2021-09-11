using AutoMapper;
using TeamsChat.Data.UnitOfWork;

namespace TeamsChat.WebApi.Controllers
{
    public class BaseController
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
