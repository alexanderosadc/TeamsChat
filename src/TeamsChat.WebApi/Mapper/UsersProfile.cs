using AutoMapper;
using TeamsChat.DataObjects;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UsersDTO>();
            CreateMap<UsersDTO, Users>();
        }
    }
}
