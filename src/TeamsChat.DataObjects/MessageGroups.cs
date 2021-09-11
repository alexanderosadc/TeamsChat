namespace TeamsChat.DataObjects
{
    public class MessageGroups : Entity
    {
        public string Title { get; set; }
        public int MessageId { get; set; }
        public Messages Messages { get; set; }
    }
}
