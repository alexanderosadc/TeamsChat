using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using TeamsChat.DatabaseInterface;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.WebApi.Common;
using TeamsChat.WebApi.DTO;
using TeamsChat.TimeoutService.Models;
using System.Net;
using System;

namespace TeamsChat.WebApi.DbCommunicators
{
    public class MessagesCommunicator
    {
        private ISSMSUnitOfWork _database;
        private IMapper _mapper;
        private IControllerManager _controllerManager;
        public MessagesCommunicator(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager)
        {
            _database = databaseFactory.GetDb<ISSMSUnitOfWork>();
            _mapper = mapper;
            _controllerManager = controllerManager;
        }

        public TimeoutResult<IEnumerable<MessageDTO>> GetMessages(HttpContext httpContext)
        {
            var result = new TimeoutResult<IEnumerable<MessageDTO>>();
            
            var messagesDTO = _database.GetRepository<Message>().GetList(
                selector: message => _mapper.Map<MessageDTO>(message),
                include: message => message
                    .Include(message => message.MessageGroup)
                    .Include(message => message.User));

            if (messagesDTO.Count() == 0)
            {
                _controllerManager.CreateLog(httpContext, 204);
                result.StatusCode = HttpStatusCode.NoContent;
                return result;
            }

            _controllerManager.CreateLog(httpContext, 200);
            result.StatusCode = HttpStatusCode.OK;
            result.Data = messagesDTO;
            return result;
        }

        public TimeoutResult<IEnumerable<MessageDTO>> GetMessagesByGroupId(TimeoutParameters<int> messageParams)
        {
            var httpContext = messageParams.HttpContext;

            var result = new TimeoutResult<IEnumerable<MessageDTO>>();
            var messageDTO = _database.GetRepository<Message>().GetList(
                selector: message => _mapper.Map<MessageDTO>(message),
                filter: message => message.MessageGroup.ID == messageParams.Container,
                include: message => message
                    .Include(message => message.MessageGroup)
                    .Include(message => message.User));

            if (messageDTO.Count() == 0)
            {
                _controllerManager.CreateLog(httpContext, 204);
                result.StatusCode = HttpStatusCode.NoContent;
                return result;
            }

            _controllerManager.CreateLog(httpContext, 200);
            result.StatusCode = HttpStatusCode.OK;
            result.Data = messageDTO;
            return result;
        }

        public TimeoutResult<MessageDTO> PostMessage(TimeoutParameters<MessageDTO> messageParams)
        {
            MessageDTO messageDTO = messageParams.Container;
            var httpContext = messageParams.HttpContext;
            var result = new TimeoutResult<MessageDTO>();

            var messageGroupDb = _database.GetRepository<MessageGroup>().SingleOrDefault(
                filter: group => group.ID == messageDTO.MessageGroup.ID);

            var userDb = _database.GetRepository<User>().SingleOrDefault(
                filter: user => user.ID == messageDTO.User.ID);

            var messageToDb = new Message
            {
                Text = messageDTO.Text,
                CreatedAt = DateTime.Now,
                MessageGroup = messageGroupDb,
                User = userDb
            };

            _database.GetRepository<Message>().Insert(messageToDb);
            _database.SaveChanges();

            if (messageToDb.ID == 0)
            {
                _controllerManager.CreateLog(httpContext, 500);
                result.StatusCode = HttpStatusCode.InternalServerError;
                return result;
            }

            _controllerManager.CreateLog(httpContext, 201);
            result.StatusCode = HttpStatusCode.Created;
            return result;
        }
    }
}
