using System;
using MediatR;

namespace LineService.Application.Features.Webhook.Commands.WebhookEvent
{
	public class WebhookEventCommand : IRequest
    {
        public string? destination { get; set; }
        public List<_event>? events { get; set; }      
	}

    public class _event
    {
        public string? type { get; set; }
        public _message? message { get; set; }
        public string? webhookEventId { get; set; }
        public _deliveryContext? deliveryContext { get; set; }
        public long timestamp { get; set; }
        public _source? source { get; set; }
        public string? replyToken { get; set; }
        public string? mode { get; set; }
    }

    public class _message
    {
        public string? type { get; set; }
        public string? id { get; set; }
        public string? quoteToken { get; set; }
        public string? text { get; set; }
    }

    public class _deliveryContext
    {
        public bool isRedelivery { get; set; }
    }

    public class _source
    {
        public string? type { get; set; }
        public string? userId { get; set; }
    }
}

