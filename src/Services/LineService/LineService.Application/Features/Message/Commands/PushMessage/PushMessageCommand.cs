using System;
using MediatR;

namespace LineService.Application.Features.Message.Commands.PushMessage
{
	public class PushMessageCommand : IRequest
	{
		public string? text { get; set; }
	}
}

