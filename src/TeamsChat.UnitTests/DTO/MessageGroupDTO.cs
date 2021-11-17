using System.Collections.Generic;

namespace TeamsChat.WebApi.DTO
{
    public class MessageGroupDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<UserDTO> Users { get; set; }

    }
}
