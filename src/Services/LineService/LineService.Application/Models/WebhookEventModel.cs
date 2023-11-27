using System;
namespace LineService.Application.Models
{
	public class WebhookEventModel
	{
        public string? destination { get; set; }
        public List<object>? events { get; set; }
    }
}

