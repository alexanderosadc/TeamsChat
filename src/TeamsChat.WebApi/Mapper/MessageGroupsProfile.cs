using AutoMapper;
using TeamsChat.DataObjects;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class MessageGroupsProfile: Profile
    {
        public MessageGroupsProfile()
        {
            CreateMap<MessageGroups, MessageGroupsDTO>();
            CreateMap<MessageGroupsDTO, MessageGroups>();
        }
    }
}
