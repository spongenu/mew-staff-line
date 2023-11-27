using System;
namespace LineService.Application.Models
{
	public class WebhookEventModel
	{
        public string? destination { get; set; }
        public List<object>? events { get; set; }
    }

    public class ReplyMessageModel
    {
        public string? replyToken { get; set; }
        public List<MessageModel>? messages { get; set; }        
    }

    public class MessageModel
    {        
        public string? type { get; set; }
        public string? text { get; set; }
    }
}

