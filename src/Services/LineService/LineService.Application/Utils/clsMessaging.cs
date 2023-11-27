using System;
using LineService.Application.Features.Webhook.Commands.WebhookEvent;
using LineService.Application.Models;
using Newtonsoft.Json;
using RestSharp;

namespace LineService.Application.Utils
{
	public class clsMessaging
	{
        public static async Task SendReplyMessagesAsync(string? message,string? replyToken)
        {            
            var url = "https://api.line.me/v2/bot/message";
            var resource = "/reply";
            var accessToken = "4cVKinTp726MgjNxPA5ljlQMMKp+hpd6q4XoqeXCKjqLjrqOu3vQBc0qzQ6VPqJhNIewH7sORzSJZFsiwyhu8KqDD9Fg8NcGML7q/XF0e/+A7spPCuBSYsBSBf+K9OZtT4g0QEs82P4MzwZl4iYj5gdB04t89/1O/w1cDnyilFU=";

            var restClient = new RestClient(url);
            var request = new RestRequest(resource);

            var messages = new List<MessageModel>();
            messages.Add(new MessageModel { type="text",text=message});

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

            //return content;
        }
    }
}

