using AutoMapper;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
