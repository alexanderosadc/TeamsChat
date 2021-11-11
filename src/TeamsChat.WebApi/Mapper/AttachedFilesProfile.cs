using AutoMapper;
using TeamsChat.DataObjects.SSMSModels;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.WebApi.Mapper
{
    public class AttachedFilesProfile: Profile
    {
        public AttachedFilesProfile()
        {
            CreateMap<AttachedFile, AttachedFileDTO>();
            CreateMap<AttachedFileDTO, AttachedFile>();
        }
    }
}
