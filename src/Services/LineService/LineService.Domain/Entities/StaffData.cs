using System;
using LineService.Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LineService.Domain.Entities
{
	public class StaffData : EnityBase
    {
        public string? Uid { get; set; }
        public string? DisplayName { get; set; }
        public string? Name { get; set; }
        public string? PictureUrl { get; set; }
        public string? Status { get; set; }
        public string? Role { get; set; }
        public List<string>? WorkShift { get; set; }
    }
}

