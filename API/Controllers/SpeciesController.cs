using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize(Roles = "Admin")]

    public class SpeciesController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public SpeciesController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SpeciesDto>>> Get()
        {
            var Species = await _unitOfWork.Species.GetAllAsync();
            return mapper.Map<List<SpeciesDto>>(Species);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<SpecieswithBreedDto>>> Get11([FromQuery] Params speciesParams)
        {
            var species = await _unitOfWork.Species.GetAllAsync(speciesParams.PageIndex, speciesParams.PageSize, speciesParams.Search,"Id");
            var speciesList = mapper.Map<List<SpecieswithBreedDto>>(species.registros);
           return new Pager<SpecieswithBreedDto>(speciesList, species.totalRegistros ,speciesParams.PageIndex,speciesParams.PageSize,speciesParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Species>> Post(SpeciesDto SpeciesDto)
        {
            var Species = this.mapper.Map<Species>(SpeciesDto);
            _unitOfWork.Species.Add(Species);
            await _unitOfWork.SaveAsync();

            if (Species == null)
            {
                return BadRequest();
            }
            SpeciesDto.Id = Species.Id;
            return CreatedAtAction(nameof(Post), new { id = SpeciesDto.Id }, Species);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SpeciesDto>> Get(int id)
        {
            var Species = await _unitOfWork.Species.GetByIdAsync(id);
            return mapper.Map<SpeciesDto>(Species);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SpeciesDto>> Put(int id, [FromBody] SpeciesDto SpeciesDto)
        {
            if (SpeciesDto == null)
                return NotFound();

            var Species = this.mapper.Map<Species>(SpeciesDto);
            _unitOfWork.Species.Update(Species);
            await _unitOfWork.SaveAsync();
            return SpeciesDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Species = await _unitOfWork.Species.GetByIdAsync(id);
            if (Species == null)
                return NotFound();

            _unitOfWork.Species.Remove(Species);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}