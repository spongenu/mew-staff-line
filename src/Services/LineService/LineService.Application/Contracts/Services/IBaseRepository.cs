using System;
namespace LineService.Application.Contracts.Services
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity obj);
        void Update(TEntity obj, string id);
        void Delete(string id);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> Get();
    }
}

