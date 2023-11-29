using System;
using LineService.Application.Utils;
using MediatR;

namespace LineService.Application.Features.Message.Commands.PushMessage
{
	public class PushMessageCommandHandler : IRequestHandler<PushMessageCommand>
    {
		public PushMessageCommandHandler()
		{
		}

        public async Task<Unit> Handle(PushMessageCommand request, CancellationToken cancellationToken)
        {
            await clsMessaging.PushMessagesAsync(request.text, "Ucee504c3c1a662adcae85a1b126cfe93");
            //Ue1245ce5bf9044a7df744477fb68b9f1
            throw new NotImplementedException();
        }
    }
}

