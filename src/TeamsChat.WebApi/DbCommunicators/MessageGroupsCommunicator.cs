using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TeamsChat.DatabaseInterface;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.SSMS.UnitOfWork;
using TeamsChat.TimeoutService.Models;
using TeamsChat.WebApi.Common;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.DbCommunicators
{
    public class MessageGroupsCommunicator
    {
        private ISSMSUnitOfWork _database;
        private IMapper _mapper;
        private IControllerManager _controllerManager;
        public MessageGroupsCommunicator(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager)
        {
            _database = databaseFactory.GetDb<ISSMSUnitOfWork>();
            _mapper = mapper;
            _controllerManager = controllerManager;
        }

        public TimeoutResult<IEnumerable<MessageGroupDTO>> GetGroups(HttpContext httpContext)
        {
            var result = new TimeoutResult<IEnumerable<MessageGroupDTO>>();

            var messagesDTO = _database.GetRepository<MessageGroup>().GetList(
                selector: message => _mapper.Map<MessageGroupDTO>(message));

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
        public TimeoutResult<bool> PostGroup(TimeoutParameters<MessageGroupDTO> messageGroupParams)
        {
            var result = new TimeoutResult<bool>();

            MessageGroupDTO groupDTO = messageGroupParams.Container;
            var httpContext = messageGroupParams.HttpContext;

            var users = _database.GetRepository<User>().GetList(
                selector: user => user,
                filter: user => groupDTO.Users.Select(userDto => userDto.ID).Contains(user.ID)).ToList();

            var groupToDb = new MessageGroup
            {
                Title = groupDTO.Title,
                Users = users
            };

            _database.GetRepository<MessageGroup>().Insert(groupToDb);
            _database.SaveChanges();

            if (groupToDb.ID == 0)
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
