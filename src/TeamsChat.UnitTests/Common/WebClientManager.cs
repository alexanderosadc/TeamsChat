using System.Net;

namespace TeamsChat.UnitTests.Common
{
    public static class WebClientManager
    {
        private static string _host = "https://localhost:44342/";
        public static string GetResponse(string urlPath)
        {
            WebClient client = new WebClient();
            return client.DownloadString(_host + urlPath);
        }
        public static string PostRequest(string urlPath, string jsonString)
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = client.UploadString(_host + urlPath, jsonString);

            return response;
        }
    }
}
