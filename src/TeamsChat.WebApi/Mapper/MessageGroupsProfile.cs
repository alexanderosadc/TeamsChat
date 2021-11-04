using AutoMapper;
using TeamsChat.DataObjects.MSSQLModels;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class MessageGroupsProfile: Profile
    {
        public MessageGroupsProfile()
        {
            CreateMap<MessageGroup, MessageGroupDTO>();
            CreateMap<MessageGroupDTO, MessageGroup>();
        }
    }
}
