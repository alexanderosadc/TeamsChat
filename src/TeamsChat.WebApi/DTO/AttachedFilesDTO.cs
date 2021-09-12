using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamsChat.WebApi.DTO
{
    public class AttachedFilesDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public string MimeType { get; set; }
    }
}
