namespace TeamsChat.WebApi.DTO
{
    public class AttachedFileDTO
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public string MimeType { get; set; }
        public MessageDTO Message { get; set; }
    }
}
