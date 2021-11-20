using System;

namespace TeamsChat.DataObjects.SSMSModels
{ 
    public class Message : Entity
    {
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public MessageGroup MessageGroup { get; set; }
        public User User { get; set; }
    }
}
