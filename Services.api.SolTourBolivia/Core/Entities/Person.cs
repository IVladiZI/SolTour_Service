using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Core.Entities
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("documentNumber")]
        public string DocumentNumber { get; set; }
        [BsonElement("extension")]
        public string Extension { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("firstLastName")]
        public string FirstLastName { get; set; }
        [BsonElement("secondLastName")]
        public string SecondLastName { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("state")]
        public bool State { get; set; }
    }
}
