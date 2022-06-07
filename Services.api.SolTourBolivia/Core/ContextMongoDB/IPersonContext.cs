using MongoDB.Driver;
using Services.api.SolTourBolivia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Core.ContextMongoDB
{
    public interface IPersonContext
    {
        IMongoCollection<Person> Persons { get; }

    }
}
