using LineService.Application.Utils;
using MediatR;

namespace LineService.Application.Features.Webhook.Commands.WebhookEvent
{
	public class WebhookEventCommandHandler : IRequestHandler<WebhookEventCommand>
	{
		public WebhookEventCommandHandler()
		{
		}

        public async Task<Unit> Handle(WebhookEventCommand request, CancellationToken cancellationToken)
        {
            await clsMessaging.SendReplyMessagesAsync("hi", request.events![0].replyToken);
            throw new NotImplementedException();
        }
    }
}

