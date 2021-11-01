using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.DataObjects;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesConstroller : BaseController
    {
        public MessagesConstroller(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

        [HttpGet]
        public IEnumerable<MessageDTO> GetMessages()
        {
            var data = _database.GetRepository<Message>().GetList(
                selector: message => _mapper.Map<MessageDTO>(message),
                include: message => message
                    .Include(message => message.MessageGroup)
                    .Include(message => message.User));

            return data;
        }
    }
}
