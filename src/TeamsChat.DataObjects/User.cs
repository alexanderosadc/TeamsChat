using System.Collections.Generic;

namespace TeamsChat.DataObjects
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<MessageGroup> MessageGroups { get; set; }

    }
}
