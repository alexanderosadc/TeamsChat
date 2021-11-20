using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TeamsChat.DatabaseInterface;
using TeamsChat.MongoDbService.ModelRepositories;
using TeamsChat.TimeoutService.Models;
using TeamsChat.WebApi.Common;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.DbCommunicators
{
    public class LogsCommunicator
    {
        private ILogsRepository _logsRepository;
        private IMapper _mapper;
        private IControllerManager _controllerManager;
        public LogsCommunicator(IDatabaseFactory databaseFactory, IMapper mapper, IControllerManager controllerManager)
        {
            _logsRepository = databaseFactory.GetDb<ILogsRepository>();
            _mapper = mapper;
            _controllerManager = controllerManager;
        }

        public TimeoutResult<IEnumerable<LogDTO>> GetAllLogs()
        {
            var result = new TimeoutResult<IEnumerable<LogDTO>>();
            var logsDb = _logsRepository.GetAll();

            if (logsDb.Count() == 0)
            {
                result.StatusCode = HttpStatusCode.NoContent;
                return result;
            }

            IList<LogDTO> logs = new List<LogDTO>();

            foreach (var log in logsDb)
            {
                logs.Add(_mapper.Map<LogDTO>(log));
            }

            result.Data = logs;
            result.StatusCode = HttpStatusCode.OK;
            return result;
        }
    }
}
