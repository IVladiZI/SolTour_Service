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
    public class TouristPlaceController : ControllerBase
    {
        private readonly IMongoRepository<TouristPlaceEntity> _touristPlaceGenericRepository;

        public TouristPlaceController(IMongoRepository<TouristPlaceEntity> touristPlaceGenericRepository)
        {
            _touristPlaceGenericRepository = touristPlaceGenericRepository;
        }

        [HttpPost("pagination")]
        public async Task<ActionResult<PaginationEntity<TouristPlaceEntity>>> PostPagination(PaginationEntity<TouristPlaceEntity> paginationEntity)
        {
            var result = await _touristPlaceGenericRepository.PaginationBy(
                filter => filter.Name == paginationEntity.filter,
                paginationEntity
                );
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TouristPlaceEntity>>> Get()
        {
            return Ok(await _touristPlaceGenericRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TouristPlaceEntity>>> GetById(string id)
        {
            var person = await _touristPlaceGenericRepository.GetById(id);
            return Ok(person);
        }
        [HttpPost]
        public async Task Post(TouristPlaceEntity touristPlaceEntity)
        {
            await _touristPlaceGenericRepository.InserDocument(touristPlaceEntity);
        }
    }
}
