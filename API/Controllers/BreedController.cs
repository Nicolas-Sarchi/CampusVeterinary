using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
namespace API.Controllers
{
    public class BreedController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BreedController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
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
            Breed.Id = Breed.Id;
            return CreatedAtAction(nameof(Post), new { id = Breed.Id }, Breed);
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