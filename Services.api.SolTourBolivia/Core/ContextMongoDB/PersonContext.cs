using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.api.SolTourBolivia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Core.ContextMongoDB
{
    public class PersonContext : IPersonContext
    {
        private readonly IMongoDatabase _db;
        public PersonContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Person> Persons => _db.GetCollection<Person>("Person");

    }
}
