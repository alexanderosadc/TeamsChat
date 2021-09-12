using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsChat.Data.UnitOfWork;

namespace TeamsChat.WebApi.Controllers
{
    public class MessagesConstroller : BaseController
    {
        public MessagesConstroller(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

        [HttpGet]
        public void GetMessages()
        {

        }
    }
}
