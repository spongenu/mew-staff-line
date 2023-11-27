using System;
namespace LineService.Application.Models
{
    public class ReplyMessageModel
    {
        public string? replyToken { get; set; }
        public List<_message>? messages { get; set; }
    }

    public class PushMessageModel
    {
        public string? to { get; set; }
        public List<_message>? messages { get; set; }
    }

    public class _message
    {
        public string? type { get; set; }
        public string? text { get; set; }
    }
}

