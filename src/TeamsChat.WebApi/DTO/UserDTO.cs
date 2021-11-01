using System.Collections.Generic;

namespace TeamsChat.WebApi.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<MessageGroupDTO> MessageGroups { get; set; }
    }
}
