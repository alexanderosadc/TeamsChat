using AutoMapper;
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
    public class UsersCommunicator
    {
        private ISSMSUnitOfWork _database;
        private IMapper _mapper;
        private IControllerManager _controllerManager;
        public UsersCommunicator(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager)
        {
            _database = databaseFactory.GetDb<ISSMSUnitOfWork>();
            _mapper = mapper;
            _controllerManager = controllerManager;
        }

        public TimeoutResult<IList<UserDTO>> GetUserByName(TimeoutParameters<UserDTO> userParams)
        {
            UserDTO userDTO = userParams.Container;
            var httpContext = userParams.HttpContext;
            var result = new TimeoutResult<IList<UserDTO>>();

            var usersDb = _database.GetRepository<User>()
                .GetList(
                    selector: user => user,
                    filter: user => (userDTO.FirstName == null || user.FirstName.ToLower().Contains(userDTO.FirstName))
                        && (userDTO.LastName == null || user.LastName.ToLower().Contains(userDTO.LastName)));

            if (usersDb.Count() == 0)
            {
                _controllerManager.CreateLog(httpContext, 204);
                result.StatusCode = HttpStatusCode.NoContent;
                return result;
            }

            IList<UserDTO> users = new List<UserDTO>();

            foreach (var user in usersDb)
            {
                users.Add(_mapper.Map<UserDTO>(user));
            }

            _controllerManager.CreateLog(httpContext, 200);
            result.StatusCode = HttpStatusCode.OK;
            result.Data = users;

            return result;
        }

        public TimeoutResult<UserDTO> LoginUser(TimeoutParameters<UserDTO> userParams)
        {
            UserDTO userInput = userParams.Container;
            var httpContext = userParams.HttpContext;
            var result = new TimeoutResult<UserDTO>();

            if (string.IsNullOrEmpty(userInput.Email) || string.IsNullOrEmpty(userInput.Password))
            {
                _controllerManager.CreateLog(httpContext, 403);
                result.StatusCode = HttpStatusCode.Forbidden;
                return result;
            }

            var userDb = _database.GetRepository<User>()
                .SingleOrDefault(
                    filter: user => user.Email == userInput.Email && user.Password == userInput.Password,
                    include: user => user
                        .Include(user => user.MessageGroups));

            if (userDb == null)
            {
                _controllerManager.CreateLog(httpContext, 204);
                result.StatusCode = HttpStatusCode.NoContent;
                return result;
            }

            var userDto = _mapper.Map<UserDTO>(userDb);

            _controllerManager.CreateLog(httpContext, 200);
            result.StatusCode = HttpStatusCode.OK;
            result.Data = userDto;

            return result;
        }

        public TimeoutResult<bool> PostUser(TimeoutParameters<UserDTO> userParams)
        {
            UserDTO userInput = userParams.Container;
            var httpContext = userParams.HttpContext;
            var result = new TimeoutResult<bool>();

            var userToDb = new User
            {
                FirstName = userInput.FirstName,
                LastName = userInput.LastName,
                Email = userInput.Email,
                Password = userInput.Password
            };

            var user = _database.GetRepository<User>().Insert(userToDb);
            _database.SaveChanges();

            if (user.ID == 0)
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
