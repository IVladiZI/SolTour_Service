using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Core.Entities
{
    [BsonCollection("User")]
    public class UserEntity : Document
    {
        [BsonElement("userName")]
        public string UserName { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("person")]
        public PersonEntity Person { get; set; }
        [BsonElement("state")]
        public bool State { get; set; }

    }

    public class PersonEntity
    {
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
        [BsonElement("nationality")]
        public string Nationality { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("email")]
        public DateTime Email { get; set; }
    }
}
