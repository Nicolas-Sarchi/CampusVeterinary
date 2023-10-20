using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.Linq;
using API.Helpers;
namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize]
    public class PetController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PetController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PetDto>>> Get()
        {
            var Pet = await _unitOfWork.Pets.GetAllAsync();
            return _mapper.Map<List<PetDto>>(Pet);
        }
        [HttpGet("Felines")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PetDto>>> GetFelinePets()
        {
            var Pets = await _unitOfWork.Pets.FelinePets();
            return _mapper.Map<List<PetDto>>(Pets);
        }

        [HttpGet("Appointment/Vaccination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VaccinationDto>>> GetVaccinationPets()
        {
            var Pets = await _unitOfWork.Pets.VaccinationAppointment2023();
            return _mapper.Map<List<VaccinationDto>>(Pets);
        }

        [HttpGet("BySpecies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SpeciesGroupDto>>> GetPetsBySpecies()
        {
            var Pets = await _unitOfWork.Pets.PetsBySpecies();
            return _mapper.Map<List<SpeciesGroupDto>>(Pets);
        }

        [HttpGet("AttendedBy/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AttendedByDto>>> PetsAttendedByXVet(string vetName)
        {
            var Pets = await _unitOfWork.Pets.PetsAttendedByXVet(vetName);
            return _mapper.Map<List<AttendedByDto>>(Pets);
        }

        [HttpGet("Breed/Golden-Retriever")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PetDto>>> GoldenRetrievers()
        {
            var Pets = await _unitOfWork.Pets.GoldenRetriever();
            return _mapper.Map<List<PetDto>>(Pets);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PetDto>> Get(int id)
        {
            var Pet = await _unitOfWork.Pets.GetByIdAsync(id);
            return _mapper.Map<PetDto>(Pet);
        }
        [ApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PetDto>>> Get([FromQuery] Params PetParams)
        {
            var Pet = await _unitOfWork.Pets.GetAllAsync(PetParams.PageIndex, PetParams.PageSize, PetParams.Search, "Name");
            var listaPetsDto = _mapper.Map<List<PetDto>>(Pet.registros);
            return new Pager<PetDto>(listaPetsDto, Pet.totalRegistros, PetParams.PageIndex, PetParams.PageSize, PetParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pet>> Post(PetDto PetDto)
        {
            var Pet = _mapper.Map<Pet>(PetDto);
            _unitOfWork.Pets.Add(Pet);
            await _unitOfWork.SaveAsync();

            if (Pet == null)
            {
                return BadRequest();
            }
            PetDto.Id = Pet.Id;
            return CreatedAtAction(nameof(Post), new { id = PetDto.Id }, Pet);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PetDto>> Put(int id, [FromBody] PetDto PetDto)
        {
            if (PetDto == null)
            {
                return NotFound();
            }
            var Pet = _mapper.Map<Pet>(PetDto);
            _unitOfWork.Pets.Update(Pet);
            await _unitOfWork.SaveAsync();
            return PetDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PetDto>> Delete(int id)
        {
            var Pet = await _unitOfWork.Pets.GetByIdAsync(id);
            if (Pet == null)
            {
                return NotFound();
            }
            _unitOfWork.Pets.Remove(Pet);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}