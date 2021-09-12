using System.Collections.Generic;

namespace TeamsChat.DataObjects
{
    public class Users : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<MessageGroups> MessageGroups { get; set; }

    }
}
