using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    public class PetController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public PetController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PetDto>>> Get()
        {
            var Pet = await _unitOfWork.Pets.GetAllAsync();
            return mapper.Map<List<PetDto>>(Pet);
        }

        [HttpGet("Felines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PetDto>>> GetFelinePets()
        {
            var Pets = await _unitOfWork.Pets.FelinePets();
            return mapper.Map<List<PetDto>>(Pets);
        }

        [HttpGet("Appointment/Vaccination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VaccinationDto>>> GetVaccinationPets()
        {
            var Pets = await _unitOfWork.Pets.VaccinationAppointment2023();
            return mapper.Map<List<VaccinationDto>>(Pets);
        }

        [HttpGet("BySpecies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SpeciesGroupDto>>> GetPetsBySpecies()
        {
            var Pets = await _unitOfWork.Pets.PetsBySpecies();
            return mapper.Map<List<SpeciesGroupDto>>(Pets);
        }

        [HttpGet("AttendedBy/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AttendedByDto>>> PetsAttendedByXVet(string vetName)
        {
            var Pets = await _unitOfWork.Pets.PetsAttendedByXVet(vetName);
            return mapper.Map<List<AttendedByDto>>(Pets);
        }

         [HttpGet("Breed/Golden-Retriever")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PetDto>>> GoldenRetrievers()
        {
            var Pets = await _unitOfWork.Pets.GoldenRetriever();
            return mapper.Map<List<PetDto>>(Pets);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pet>> Post(PetDto PetDto)
        {
            var Pet = this.mapper.Map<Pet>(PetDto);
            _unitOfWork.Pets.Add(Pet);
            await _unitOfWork.SaveAsync();

            if (Pet == null)
            {
                return BadRequest();
            }
            PetDto.Id = Pet.Id;
            return CreatedAtAction(nameof(Post), new { id = PetDto.Id }, Pet);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PetDto>> Get(int id)
        {
            var Pet = await _unitOfWork.Pets.GetByIdAsync(id);
            return mapper.Map<PetDto>(Pet);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PetDto>> Put(int id, [FromBody] PetDto PetDto)
        {
            if (PetDto == null)
                return NotFound();

            var Pet = this.mapper.Map<Pet>(PetDto);
            _unitOfWork.Pets.Update(Pet);
            await _unitOfWork.SaveAsync();
            return PetDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Pet = await _unitOfWork.Pets.GetByIdAsync(id);
            if (Pet == null)
                return NotFound();

            _unitOfWork.Pets.Remove(Pet);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}