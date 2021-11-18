using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamsChat.UnitTests.Common;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.UnitTests.ControllerTests
{
    [TestClass]
    public class MessagesControllerTest
    {
        [TestMethod]
        public void GetMessagesTest()
        {
            string content = WebClientManager.GetResponse("Messages");

            var messagesCount = JsonConvert.DeserializeObject<IEnumerable<MessageDTO>>(content).Count();

            var isResponseFilled = false;

            if(messagesCount > 0)
                isResponseFilled = true;

            Assert.AreEqual(isResponseFilled, true);
        }

        [TestMethod]
        public void GetMessagesByGroupIdTest()
        {
            int groupId = 1;
            string content = WebClientManager.GetResponse("Messages/groupId=" + groupId.ToString());

            var message = JsonConvert.DeserializeObject<IEnumerable<MessageDTO>>(content).FirstOrDefault();

            Assert.AreEqual(message.MessageGroup.ID, groupId);
        }
        [TestMethod]
        public void PostMessageTest()
        {
            MessageDTO messageToCreate = new MessageDTO
            {
                Text = "Test message second",
                CreatedAt = DateTime.Now,
                MessageGroup = new MessageGroupDTO
                {
                    ID = 2,
                    Title = "PAD",
                    Users = null
                },
                User = new UserDTO
                {
                    ID = 3,
                    FirstName = "Vova",
                    LastName = "Leadavschi",
                    Email = "vova.leadavschi@gmail.com",
                    Password = "pass3"
                }
            };


            WebClientManager.PostRequest("Messages", JsonConvert.SerializeObject(messageToCreate));

            int groupId = 2;
            string content = WebClientManager.GetResponse("Messages/groupId=" + groupId.ToString());

            var message = JsonConvert.DeserializeObject<IEnumerable<MessageDTO>>(content);

            var singleMessageReceived = message.Select(message => message.Text = messageToCreate.Text).FirstOrDefault();

            var isResponseFilled = false;

            if (singleMessageReceived.Length > 0)
                isResponseFilled = true;

            Assert.AreEqual(isResponseFilled, true);
        }
    }
}
