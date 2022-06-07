using Services.api.SolTourBolivia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersons();
    }
}
