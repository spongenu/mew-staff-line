using System;
using LineService.Application.Contracts.Services;
using LineService.Domain.Entities;
using LineService.Infrastructure.Data;
using MongoDB.Driver;

namespace LineService.Infrastructure.Service
{
	public class LineServiceRepository : BaseRepository<StaffData>, ILineServiceRepository
    {
        public LineServiceRepository(ILineContext context) : base(context)
        {
            //var incomeDateIndexKeys = Builders<BankIncomeData>.IndexKeys.Descending(x => x.IncomeDate);
            //var incomeDateIndexModel = new CreateIndexModel<BankIncomeData>(incomeDateIndexKeys);
            //_dbCollection.Indexes.CreateOne(incomeDateIndexModel);

            //var usernameIndexKeys = Builders<BankIncomeData>.IndexKeys.Descending(x => x.UserName);
            //var usernameIndexModel = new CreateIndexModel<BankIncomeData>(usernameIndexKeys);
            //_dbCollection.Indexes.CreateOne(usernameIndexModel);
        }

        public async Task<bool> IsExistUid(string Uid)
        {
            var filter = Builders<StaffData>.Filter.Eq(p => p.Uid, Uid);
            return await _dbCollection.Find(filter).AnyAsync();            
        }
    }
}

