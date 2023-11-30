using System;
using LineService.Domain.Entities;

namespace LineService.Application.Contracts.Services
{
	public interface ILineServiceRepository : IBaseRepository<StaffData>
	{
        Task<bool> IsExistUid(string Uid);
    }
}

