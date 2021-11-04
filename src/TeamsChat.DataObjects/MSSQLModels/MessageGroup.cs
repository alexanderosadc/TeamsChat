using System.Collections.Generic;

namespace TeamsChat.DataObjects.MSSQLModels
{
    public class MessageGroup : Entity
    {
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
