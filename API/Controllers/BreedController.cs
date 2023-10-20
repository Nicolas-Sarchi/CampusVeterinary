using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using API.Helpers;
namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class BreedController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BreedController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BreedDto>>> Get()
        {
            var Breed = await _unitOfWork.Breeds.GetAllAsync();
            return _mapper.Map<List<BreedDto>>(Breed);
        }
        [HttpGet("petsNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Object>>> GetPetsPerBreed()
        {
            var Breed = await _unitOfWork.Breeds.PetsPerBreed();


            return Ok(Breed);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BreedDto>> Get(int id)
        {
            var Breed = await _unitOfWork.Breeds.GetByIdAsync(id);
            return _mapper.Map<BreedDto>(Breed);
        }
        [ApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<BreedDto>>> Get([FromQuery] Params BreedParams)
        {
            var Breed = await _unitOfWork.Breeds.GetAllAsync(BreedParams.PageIndex, BreedParams.PageSize, BreedParams.Search, "Name");
            var listaBreedsDto = _mapper.Map<List<BreedDto>>(Breed.registros);
            return new Pager<BreedDto>(listaBreedsDto, Breed.totalRegistros, BreedParams.PageIndex, BreedParams.PageSize, BreedParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Breed>> Post(BreedDto BreedDto)
        {
            var Breed = _mapper.Map<Breed>(BreedDto);
            _unitOfWork.Breeds.Add(Breed);
            await _unitOfWork.SaveAsync();

            if (Breed == null)
            {
                return BadRequest();
            }
            BreedDto.Id = Breed.Id;
            return CreatedAtAction(nameof(Post), new { id = BreedDto.Id }, Breed);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BreedDto>> Put(int id, [FromBody] BreedDto BreedDto)
        {
            if (BreedDto == null)
            {
                return NotFound();
            }
            var Breed = _mapper.Map<Breed>(BreedDto);
            _unitOfWork.Breeds.Update(Breed);
            await _unitOfWork.SaveAsync();
            return BreedDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BreedDto>> Delete(int id)
        {
            var Breed = await _unitOfWork.Breeds.GetByIdAsync(id);
            if (Breed == null)
            {
                return NotFound();
            }
            _unitOfWork.Breeds.Remove(Breed);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}