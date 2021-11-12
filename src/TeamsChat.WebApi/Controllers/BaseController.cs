using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.WebApi.Common;

namespace TeamsChat.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ISSMSUnitOfWork _database;
        protected readonly IMapper _mapper;
        protected readonly IControllerManager _controllerManager;

        public BaseController(ISSMSUnitOfWork database, IMapper mapper, IControllerManager controllerManager)
        {
            _database = database;
            _mapper = mapper;
            _controllerManager = controllerManager;
        }
    }
}
