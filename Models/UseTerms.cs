﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;


namespace Models
{
    public class UseTerms
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
        public int Version { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }
    }
}
