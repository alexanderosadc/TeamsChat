using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamsChat.DataObjects.MongoDbModels;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly IMongoRepository<Logs> _peopleRepository;

        public SampleController(IMongoRepository<Logs> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpPost("registerLogs")]
        public async Task AddPerson([FromQuery] string request, string response)
        {
            var person = new Logs()
            {
                Request = request,
                Response = response
            };

            await _peopleRepository.InsertOneAsync(person);
        }

        [HttpGet("getLogByResponse")]
        public Logs GetPeopleData([FromQuery] string response)
        {
            var logs = _peopleRepository.FindOne(
                filter => filter.Response == response);

            return logs;
        }
    }
}
