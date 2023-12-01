using MediatR;

namespace LineService.Application.Features.User.Queries.GetScheduleByIdToken
{
	public class GetScheduleByIdTokenQuery : IRequest<GetScheduleByIdTokenQueryVm>
    {
        public string? IdToken { get; set; }
    }
}

	