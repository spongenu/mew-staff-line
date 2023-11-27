using System;
using MediatR;

namespace LineService.Application.Features.Webhook.Commands.WebhookEvent
{
	public class WebhookEventCommandHandler : IRequestHandler<WebhookEventCommand, WebhookEventCommandVm>
	{
		public WebhookEventCommandHandler()
		{
		}

        public Task<WebhookEventCommandVm> Handle(WebhookEventCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}

