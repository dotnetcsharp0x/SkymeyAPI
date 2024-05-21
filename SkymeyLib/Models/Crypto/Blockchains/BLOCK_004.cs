﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.IdGenerators;

namespace SkymeyLib.Models.Crypto.Blockchains
{
    public class BLOCK_004
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        public ObjectId? _id { get; set; }
        [JsonPropertyName("Id")]
        [BsonElement("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Title")]
        [BsonElement("Title")]
        public string Title { get; set; }
        [JsonPropertyName("Symbol")]
        [BsonElement("Symbol")]
        public string? Symbol { get; set; }
        [JsonPropertyName("Update")]
        [BsonElement("Update")]
        public DateTime Update { get; set; }

        public BLOCK_004()
        {
            _id = ObjectId.GenerateNewId();
        }
    }
}
