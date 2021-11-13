using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.DatabaseInterface;
using TeamsChat.WebApi.Common;

namespace TeamsChat.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IDatabaseFactory _databaseFactory;
        protected readonly IMapper _mapper;
        protected readonly IControllerManager _controllerManager;

        public BaseController(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager)
        {
            _databaseFactory = databaseFactory;
            _mapper = mapper;
            _controllerManager = controllerManager;
        }
    }
}
