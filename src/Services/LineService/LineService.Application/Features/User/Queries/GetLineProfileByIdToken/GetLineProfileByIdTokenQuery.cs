using System;
using MediatR;

namespace LineService.Application.Features.User.Queries.GetLineProfileByIdToken
{
	public class GetLineProfileByIdTokenQuery : IRequest<GetLineProfileByIdTokenQueryVm>
    {
        public string? IdToken { get; set; }
    }
}



