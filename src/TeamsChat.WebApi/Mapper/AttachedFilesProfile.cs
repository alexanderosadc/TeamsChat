using AutoMapper;
using TeamsChat.DataObjects;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class AttachedFilesProfile: Profile
    {
        public AttachedFilesProfile()
        {
            CreateMap<AttachedFiles, AttachedFilesDTO>();
            CreateMap<AttachedFilesDTO, AttachedFiles>();
        }
    }
}
