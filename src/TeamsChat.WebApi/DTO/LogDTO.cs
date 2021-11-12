using System;

namespace TeamsChat.WebApi.DTO
{
    public class LogDTO
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Request { get; set; }
        public string Method { get; set; }
        public int StatusCode { get; set; }
    }
}
