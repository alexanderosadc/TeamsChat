using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TeamsChat.UnitTests.Common;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.UnitTests.ControllerTests
{
    [TestClass]
    public class MessageGroupsControllerTest
    {
        [TestMethod]
        public void GetGroupsTest()
        {
            string content = WebClientManager.GetResponse("MessageGroups");

            var groupsCount = JsonConvert.DeserializeObject<IEnumerable<LogDTO>>(content).Count();

            var isResponseFilled = false;

            if (groupsCount > 0)
                isResponseFilled = true;

            Assert.AreEqual(isResponseFilled, true);
        }

        [TestMethod]
        public void PostGroupTest()
        {
            MessageGroupDTO groupToCreate = new MessageGroupDTO
            {
                Title = "Group from unit test",
                Users = new List<UserDTO>
                {
                    new UserDTO
                    {
                        ID = 1,
                        FirstName = "Maxim",
                        LastName = "Volosenco",
                        Email = "maximvolosenco@gmail.com",
                        Password = "pass1"
                    }
                }
            };


            WebClientManager.PostRequest("MessageGroups", JsonConvert.SerializeObject(groupToCreate));

            string content = WebClientManager.GetResponse("MessageGroups");

            var groups = JsonConvert.DeserializeObject<IEnumerable<MessageGroupDTO>>(content);

            var singleGroupReceived = groups.Select(message => message.Title = groupToCreate.Title).FirstOrDefault();

            var isResponseFilled = false;

            if (singleGroupReceived.Length > 0)
                isResponseFilled = true;

            Assert.AreEqual(isResponseFilled, true);
        }
    }
}
