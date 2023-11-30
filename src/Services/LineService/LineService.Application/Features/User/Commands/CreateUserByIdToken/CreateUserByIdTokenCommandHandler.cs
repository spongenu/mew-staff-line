using System;
using LineService.Application.Contracts.Services;
using LineService.Application.Models;
using LineService.Application.Utils;
using LineService.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace LineService.Application.Features.User.Commands.CreateUserByIdToken
{
	public class CreateUserByIdTokenCommandHandler : IRequestHandler<CreateUserByIdTokenCommand, bool>
    {
        private readonly ILineServiceRepository _lineServiceRepository;

        public CreateUserByIdTokenCommandHandler(ILineServiceRepository lineServiceRepository)
        {
            _lineServiceRepository = lineServiceRepository ?? throw new ArgumentNullException(nameof(lineServiceRepository));
        }

        public async Task<bool> Handle(CreateUserByIdTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var lineProfile = await clsOAuth.VerifyIdTokenAsync(request.IdToken!);
                var res = JsonConvert.DeserializeObject<VerifyIdTokenModel>(lineProfile!);

                if (res != null && !string.IsNullOrEmpty(res.sub))
                {
                    var isExist = await _lineServiceRepository.IsExistUid(res.sub!);

                    if (!isExist)
                    {
                        await _lineServiceRepository.Create(new StaffData
                        {
                            Uid = res.sub!,
                            DisplayName = res.name,
                            createDate = DateTime.UtcNow,
                            updateDate = DateTime.UtcNow
                        });
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}

