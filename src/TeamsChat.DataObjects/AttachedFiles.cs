namespace TeamsChat.DataObjects
{
    public class AttachedFiles : Entity
    {
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public string MimeType { get; set; }
        public int MessagesId { get; set; }
        public Messages Messages { get; set; }
    }
}
