using Microsoft.AspNetCore.Http;
using System.Net;

namespace TeamsChat.WebApi.Common
{
    public interface IControllerManager
    {
        HttpStatusCode CreateLog(HttpContext http, int response);
    }
}
