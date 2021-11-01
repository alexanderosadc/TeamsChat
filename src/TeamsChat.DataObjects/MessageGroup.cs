using System.Collections.Generic;

namespace TeamsChat.DataObjects
{
    public class MessageGroup : Entity
    {
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
