using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsChat.Data.UnitOfWork;
using TeamsChat.DataObjects;

namespace TeamsChat.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        public WeatherForecastController(IUnitOfWork database, IMapper mapper) : base(database, mapper) { }

        //[HttpGet]
        //public IEnumerable<TestData> Get()
        //{
        //    var data = _database.GetRepository<TestData>()
        //        .GetList(selector: td => td);

            //return data;
        //}
    }
}
