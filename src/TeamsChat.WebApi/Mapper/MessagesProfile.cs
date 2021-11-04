using AutoMapper;
using TeamsChat.DataObjects.MSSQLModels;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class MessagesProfile: Profile
    {
        public MessagesProfile()
        {
            CreateMap<Message, MessageDTO>();
            CreateMap<MessageDTO, Message>();
        }
    }
}
