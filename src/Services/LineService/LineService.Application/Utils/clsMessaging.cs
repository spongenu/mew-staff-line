using LineService.Application.Models;
using RestSharp;

namespace LineService.Application.Utils
{
	public class clsMessaging
	{
        private static string url = "https://api.line.me/v2/bot/message";
        private static string accessToken = "4cVKinTp726MgjNxPA5ljlQMMKp+hpd6q4XoqeXCKjqLjrqOu3vQBc0qzQ6VPqJhNIewH7sORzSJZFsiwyhu8KqDD9Fg8NcGML7q/XF0e/+A7spPCuBSYsBSBf+K9OZtT4g0QEs82P4MzwZl4iYj5gdB04t89/1O/w1cDnyilFU=";

        public static async Task SendReplyMessagesAsync(string? message,string? replyToken)
        {                        
            var resource = "/reply";

            var restClient = new RestClient(url);
            var request = new RestRequest(resource);

            var messages = new List<_message>();
            messages.Add(new _message { type="text",text=message});

            var replyMessage = new ReplyMessageModel
            {
                replyToken=replyToken,
                messages = messages
            };

            request.Method = Method.Post;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {accessToken}");                        
            request.AddJsonBody(replyMessage);

            var response = await restClient.ExecuteAsync(request);
            var content = response.Content;            
        }

        public static async Task PushMessagesAsync(string? message, string? to)
        {
            var resource = "/push";
            var uuid = System.Guid.NewGuid();

            var restClient = new RestClient(url);
            var request = new RestRequest(resource);

            var messages = new List<_message>();
            messages.Add(new _message { type = "text", text = message });

            var pushMessage = new PushMessageModel
            {
                to = to,
                messages = messages
            };

            request.Method = Method.Post;
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", $"Bearer {accessToken}");
            request.AddHeader("x-line-retry-key", $"{uuid}");
            
            request.AddJsonBody(pushMessage);

            var response = await restClient.ExecuteAsync(request);
            var content = response.Content;
        }
    }
}

