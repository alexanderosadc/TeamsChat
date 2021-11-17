using System;

namespace TeamsChat.WebApi.DTO
{
    public class MessageDTO
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public MessageGroupDTO MessageGroup { get; set; }
        public UserDTO User { get; set; }
    }
}
