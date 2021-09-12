using System;

namespace TeamsChat.DataObjects
{
    public class Messages : Entity
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MessageGroupsId { get; set; }
        public MessageGroups MessageGroups { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
