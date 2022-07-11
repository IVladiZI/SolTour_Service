using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.api.SolTourBolivia.Core.Entities;
using Services.api.SolTourBolivia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.api.SolTourBolivia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolTourBoliviaController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMongoRepository<UserEntity> _personGenericRepository; 

        public SolTourBoliviaController(IPersonRepository personRepository, IMongoRepository<UserEntity> personGenericRepository)
        {
            _personRepository = personRepository;
            _personGenericRepository = personGenericRepository;
        }

        [HttpGet("personGeneric")]
        public async Task<ActionResult<UserEntity>> GetPersonGeneric()
        {
            var person = await _personGenericRepository.GetAll();
            return Ok(person);
        }

        [HttpGet("person")]
        public async Task<ActionResult<Core.Entities.User>> GetPerson()
        {
            var person = await _personRepository.GetPerson();
            return Ok(person);
        }
    }
}
