using MongoDB.Driver;
using Services.api.SolTourBolivia.Core.ContextMongoDB;
using Services.api.SolTourBolivia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPersonContext _personContext;
        public PersonRepository(IPersonContext personContext)
        {
            _personContext = personContext;
        }
        public async Task<IEnumerable<Person>> GetPerson()
        {
            return await _personContext.Persons.Find(p => true).ToListAsync();
        }
    }
}
