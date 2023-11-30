using System;
using LineService.Application.Models;
using RestSharp;

namespace LineService.Application.Utils
{
	public class clsOAuth
	{
        private static string url = "https://api.line.me/oauth2/v2.1";
        private static string client_id = "2001915121"; //line login channel
        private static string client_secret = "113cbcc945d3c9e7fba567c8f684590a";

        public static async Task IssueAccessTokenAsync()
        {
            var resource = "/token";

            var restClient = new RestClient(url);
            var request = new RestRequest(resource);
            var redirect_uri = "https://www.mewargame.com/";
            var code_verifier = System.Guid.NewGuid();

            //var messages = new List<_message>();
            //messages.Add(new _message { type = "text", text = message });

            //var replyMessage = new ReplyMessageModel
            //{
            //    replyToken = replyToken,
            //    messages = messages
            //};

            var param = $"grant_type=authorization_code&code=1231234123&redirect_uri={redirect_uri}&client_id={client_id}&client_secret={client_secret}&code_verifier={code_verifier}";
            request.Method = Method.Post;
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", param, ParameterType.RequestBody);
           

            //request.AddJsonBody(replyMessage);

            var response = await restClient.ExecuteAsync(request);
            var content = response.Content;
        }

        public static async Task<string?> VerifyIdTokenAsync(string idToken)
        {
            var resource = "/verify";

            var restClient = new RestClient(url);
            var request = new RestRequest(resource);
                    
            request.Method = Method.Post;
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("id_token", idToken);
            request.AddParameter("client_id", client_id);            

            var response = await restClient.ExecuteAsync(request);
            var content = response.Content;

            return content;
        }
    }
}

