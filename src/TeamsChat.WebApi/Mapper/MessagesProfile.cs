using AutoMapper;
using TeamsChat.DataObjects;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class MessagesProfile: Profile
    {
        public MessagesProfile()
        {
            CreateMap<Message, MessagesDTO>();
            CreateMap<MessagesDTO, Message>();
        }
    }
}
