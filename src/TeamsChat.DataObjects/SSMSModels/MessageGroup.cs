using System.Collections.Generic;

namespace TeamsChat.DataObjects.SSMSModels
{
    public class MessageGroup : Entity
    {
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
