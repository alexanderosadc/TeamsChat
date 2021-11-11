using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.SSMS.UnitOfWork;

namespace TeamsChat.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ISSMSUnitOfWork _database;
        protected readonly IMapper _mapper;
        protected readonly ILogsRepository _logsRepository;

        public BaseController(ISSMSUnitOfWork database, IMapper mapper, ILogsRepository logsRepository)
        {
            _database = database;
            _mapper = mapper;
            _logsRepository = logsRepository;
        }
    }
}
