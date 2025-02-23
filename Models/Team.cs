﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeamService.Models
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        
    }
}
