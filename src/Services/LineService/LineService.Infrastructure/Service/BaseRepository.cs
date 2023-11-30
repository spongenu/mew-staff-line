﻿using System;
using LineService.Application.Contracts.Services;
using LineService.Infrastructure.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LineService.Infrastructure.Service
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ILineContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(ILineContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<TEntity> Get(string id)
        {
            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _dbCollection.InsertOneAsync(obj);
        }

        public virtual void Update(TEntity obj, string id)
        {
            var objectId = new ObjectId(id);
            _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId), obj);
        }

        public void Delete(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));

        }
    }
}

