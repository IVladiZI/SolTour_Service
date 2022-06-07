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

        public SolTourBoliviaController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("persons")]
        public async Task<ActionResult<Person>> GetPerson()
        {
            var person = await _personRepository.GetPersons();
            return Ok(person);
        }
    }
}
