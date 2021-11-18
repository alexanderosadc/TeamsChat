using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamsChat.UnitTests.Common;
using TeamsChat.WebApi.DTO;

namespace TeamsChat.UnitTests.ControllerTests
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void GetUserByNameTest()
        {
            string firstName = "maxim";
            string lastName = "volosenco";

            string content = WebClientManager.GetResponse("Users/search?firstName=" + firstName + "&lastName=" + lastName);

            var user = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(content).FirstOrDefault();
                        
            Assert.AreEqual(user.FirstName.ToLower(), firstName.ToLower());
        }

        [TestMethod]
        public void LoginUserTest()
        {
            string email = "maximvolosenco@gmail.com";
            string password = "pass1";

            string content = WebClientManager.GetResponse("Users?email=" + email + "&password=" + password);

            var user = JsonConvert.DeserializeObject<UserDTO>(content);

            Console.WriteLine(user);
            Assert.AreEqual(user.Email.ToLower(), email.ToLower());
        }

        [TestMethod]
        public void PostUserTest()
        {
            UserDTO userToCreate = new UserDTO
            {
                FirstName = "Teodor",
                LastName = "Avraam",
                Email = "teodor.avraam@gmail.com",
                Password = "pass1"
            };

            WebClientManager.PostRequest("Users", JsonConvert.SerializeObject(userToCreate));

            string content = WebClientManager.GetResponse("Users?email=" + userToCreate.Email + "&password=" + userToCreate.Password);

            var user = JsonConvert.DeserializeObject<UserDTO>(content);

            Assert.AreEqual(user.FirstName, userToCreate.FirstName);
        }
    }
}
