
using Microsoft.AspNetCore.Http;

namespace TeamsChat.TimeoutService.Models
{
    public class TimeoutParameters<TObject>
    {
        public TObject Container { get; set; }
        public HttpContext HttpContext { get; set; }
    }
}
