using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace TeamsChat.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new WebClient();
            var content = client.DownloadString("https://localhost:44342/Messages");

            var data1 = "num1";
            var data2 = "num1";
            System.Diagnostics.Debug.WriteLine(content);

            Assert.AreEqual(data1, data2);
        }
    }
}
