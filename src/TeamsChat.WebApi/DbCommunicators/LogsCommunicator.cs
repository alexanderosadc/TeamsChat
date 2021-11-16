using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsChat.DatabaseInterface;
using TeamsChat.MongoDbService.ModelRepositories;
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

        public IEnumerable<LogDTO> GetAllLogs()
        {
            var logsDb = _logsRepository.GetAll();

            if (logsDb.Count() == 0)
                return new List<LogDTO>();

            IList<LogDTO> logs = new List<LogDTO>();

            foreach (var log in logsDb)
            {
                logs.Add(_mapper.Map<LogDTO>(log));
            }

            return logs;
        }
    }
}
