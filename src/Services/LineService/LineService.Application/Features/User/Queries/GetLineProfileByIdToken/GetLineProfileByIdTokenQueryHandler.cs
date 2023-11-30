using System;
using LineService.Application.Utils;
using MediatR;
using Newtonsoft.Json;

namespace LineService.Application.Features.User.Queries.GetLineProfileByIdToken
{
    public class GetLineProfileByIdTokenQueryHandler : IRequestHandler<GetLineProfileByIdTokenQuery, GetLineProfileByIdTokenQueryVm>
    {
        public GetLineProfileByIdTokenQueryHandler()
        {
        }

        public async Task<GetLineProfileByIdTokenQueryVm> Handle(GetLineProfileByIdTokenQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var lineProfile = await clsOAuth.VerifyIdTokenAsync(request.IdToken!);
                var res = JsonConvert.DeserializeObject<GetLineProfileByIdTokenQueryVm>(lineProfile!);

                return res;
            } catch (Exception ex)
            {
                return new GetLineProfileByIdTokenQueryVm();
            }
           
        }
    }
}

