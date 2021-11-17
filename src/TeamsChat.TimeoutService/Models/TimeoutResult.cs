using System.Net;

namespace TeamsChat.TimeoutService.Models
{
    public class TimeoutResult<TResult>
    {
        public TResult Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
