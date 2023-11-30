using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineService.Domain.Common
{
	public abstract class EnityBase
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
    }
}

