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
    public class PersonController : ControllerBase
    {
        private readonly IMongoRepository<PersonEntity> _personGenericRepository;
        public PersonController(IMongoRepository<PersonEntity> personGenericRepository)
        {
            _personGenericRepository = personGenericRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonEntity>>> Get()
        {
            return Ok(await _personGenericRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PersonEntity>>> GetById(string id)
        {
            var person = await _personGenericRepository.GetById(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task Post(PersonEntity personEntity)
        {
            await _personGenericRepository.InserDocument(personEntity);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, PersonEntity personEntity)
        {
            personEntity.Id = id;
            await _personGenericRepository.UpdateDocument(personEntity);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _personGenericRepository.DeleteDocument(id);
        }
    }
}
