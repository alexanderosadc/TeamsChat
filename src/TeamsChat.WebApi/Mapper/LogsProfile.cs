using AutoMapper;
using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class LogsProfile : Profile
    {
        public LogsProfile()
        {
            CreateMap<LogDTO, Logs>();
            CreateMap<Logs, LogDTO>()
                .ForMember(dto => dto.Id, conf => conf.MapFrom(log => log.Id.ToString()));
        }
    }
}
