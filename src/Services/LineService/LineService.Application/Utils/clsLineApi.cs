using System;
using LineService.Application.Models;
using RestSharp;

namespace LineService.Application.Utils
{
	public class clsLineApi
	{
        private static string url = "https://api.line.me/v2";
        //private static string url = "https://api.line.me/oauth2/v2.1";
                
        public static async Task GetUserProfileAsync(string accessToken)
        {
            var resource = "/profile";
            //var resource = "/userinfo";

            var restClient = new RestClient(url);
            var request = new RestRequest(resource);


            request.Method = Method.Get;            
            request.AddHeader("authorization", $"Bearer {accessToken}");            

            var response = await restClient.ExecuteAsync(request);
            var content = response.Content;
        }
    }
}

