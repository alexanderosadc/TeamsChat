namespace TeamsChat.DataObjects.SSMSModels
{
    public class AttachedFile : Entity
    {
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public string MimeType { get; set; }
        public Message Message { get; set; }
    }
}
