using System;
using MediatR;

namespace LineService.Application.Features.User.Commands.CreateUserByIdToken
{
	public class CreateUserByIdTokenCommand : IRequest<bool>
    {
        public string? IdToken { get; set; }
    }
}

