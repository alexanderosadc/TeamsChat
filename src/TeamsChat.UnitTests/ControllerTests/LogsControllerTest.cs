using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TeamsChat.UnitTests.Common;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.UnitTests.ControllerTests
{
    [TestClass]
    public class LogsControllerTest
    {
        [TestMethod]
        public void GetLogsTest()
        {
            string content = WebClientManager.GetResponse("Logs");

            var logsCount = JsonConvert.DeserializeObject<IEnumerable<LogDTO>>(content).Count();

            var isResponseFilled = false;

            if (logsCount > 0)
                isResponseFilled = true;

            Assert.AreEqual(isResponseFilled, true);
        }
    }
}
