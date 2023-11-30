using LineService.Application.Contracts.Services;
using LineService.Application.Utils;
using LineService.Domain.Entities;
using MediatR;

namespace LineService.Application.Features.Webhook.Commands.WebhookEvent
{
	public class WebhookEventCommandHandler : IRequestHandler<WebhookEventCommand>
	{
        private readonly ILineServiceRepository _lineServiceRepository;

        public WebhookEventCommandHandler(ILineServiceRepository lineServiceRepository)
        {
            _lineServiceRepository = lineServiceRepository ?? throw new ArgumentNullException(nameof(lineServiceRepository));
        }

        public async Task<Unit> Handle(WebhookEventCommand request, CancellationToken cancellationToken)
        {

            foreach (var _event in request.events!)
            {
                await clsMessaging.SendReplyMessagesAsync(_event.type, _event.replyToken);       
            }


            throw new NotImplementedException();
        }
    }
}

