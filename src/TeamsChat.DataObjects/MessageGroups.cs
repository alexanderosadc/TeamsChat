using System.Collections.Generic;

namespace TeamsChat.DataObjects
{
    public class MessageGroups : Entity
    {
        public string Title { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
