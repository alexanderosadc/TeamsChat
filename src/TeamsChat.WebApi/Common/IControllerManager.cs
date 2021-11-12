using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TeamsChat.WebApi.Common
{
    public interface IControllerManager
    {
        Task<HttpStatusCode> CreateLog(HttpContext http, int response);
    }
}
