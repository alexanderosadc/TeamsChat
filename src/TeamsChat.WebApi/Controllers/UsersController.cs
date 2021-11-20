using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IUnitOfWork database, IMapper mapper) : base(database, mapper) {}

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDTO dto)
        {

        }
    }
}
