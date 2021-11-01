﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.DataObjects;

namespace TeamsChat.WebApi.Controllers
{
    public class MessagesConstroller : BaseController
    {
        public MessagesConstroller(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

        [HttpGet]
        public IEnumerable<Message> GetMessages()
        {
            var data = _database.GetRepository<Message>()
                .GetList(selector: td => td);

            return data;
        }
    }
}
