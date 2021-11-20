using System.Net;

namespace TeamsChat.TimeoutService.Models
{
    public class TimeoutResponse<TResponse>
    {
        public TResponse Output { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
