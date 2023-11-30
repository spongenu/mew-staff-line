using System;
using CommonModel;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LineService.Infrastructure.Data
{
	public class LineContext : ILineContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }

        public LineContext(IOptions<MongoSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }

    public interface ILineContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
