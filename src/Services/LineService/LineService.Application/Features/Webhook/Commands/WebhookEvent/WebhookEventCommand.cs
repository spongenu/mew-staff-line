using System;
using MediatR;

namespace LineService.Application.Features.Webhook.Commands.WebhookEvent
{
	public class WebhookEventCommand : IRequest<WebhookEventCommandVm>
	{
		public WebhookEventCommand()
		{
		}
	}
}

