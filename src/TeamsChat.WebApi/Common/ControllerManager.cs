using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Linq;
using System.Threading.Tasks;
using TeamsChat.DataObjects.MongoDbModels;
using TeamsChat.MongoDbService.ModelRepositories;

namespace TeamsChat.WebApi.Common
{
    public class ControllerManager : IControllerManager
    {
        ILogsRepository _logsRepository;
        public ControllerManager(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }


        public async Task<HttpStatusCode> CreateLog(HttpContext httpContext, int response)
        {
            var requestUrl = httpContext.Request.GetDisplayUrl();
            var method = httpContext.Request.Method;

            Logs logToDb = new Logs { Request = requestUrl, Method = method, StatusCode = response };

            _logsRepository.Insert(logToDb);

            var logDb = await _logsRepository.GetFiltered(
                filterExpression: log => log.Id == logToDb.Id);

            if (logDb.Count() == 0)
                return HttpStatusCode.NotFound;

            return HttpStatusCode.OK;
        }
    }

    public enum HttpStatusCode
    {
        NotFound = 404,
        OK = 200
    }
}
