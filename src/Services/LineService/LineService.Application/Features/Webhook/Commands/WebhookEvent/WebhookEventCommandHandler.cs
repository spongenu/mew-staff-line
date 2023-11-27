using LineService.Application.Utils;
using MediatR;

namespace LineService.Application.Features.Webhook.Commands.WebhookEvent
{
	public class WebhookEventCommandHandler : IRequestHandler<WebhookEventCommand, WebhookEventCommandVm>
	{
		public WebhookEventCommandHandler()
		{
		}

        public async Task<WebhookEventCommandVm> Handle(WebhookEventCommand request, CancellationToken cancellationToken)
        {

            await clsMessaging.SendReplyMessagesAsync("hi", request.events![0].replyToken);
            throw new NotImplementedException();
        }
    }
}

