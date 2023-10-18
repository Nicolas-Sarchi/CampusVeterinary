using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class VetController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public VetController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VetDto>>> Get()
        {
            var Vet = await _unitOfWork.Vets.GetAllAsync();
            return mapper.Map<List<VetDto>>(Vet);
        }

        [HttpGet("Specialization/Vascular-Surgeon")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VetDto>>> GetVascularSurgeonVets()
        {
            var Vet = await _unitOfWork.Vets.VascularSurgeonVets();
            return mapper.Map<List<VetDto>>(Vet);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Vet>> Post(VetDto VetDto)
        {
            var Vet = this.mapper.Map<Vet>(VetDto);
            _unitOfWork.Vets.Add(Vet);
            await _unitOfWork.SaveAsync();

            if (Vet == null)
            {
                return BadRequest();
            }
            VetDto.Id = Vet.Id;
            return CreatedAtAction(nameof(Post), new { id = VetDto.Id }, Vet);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VetDto>> Get(int id)
        {
            var Vet = await _unitOfWork.Vets.GetByIdAsync(id);
            return mapper.Map<VetDto>(Vet);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VetDto>> Put(int id, [FromBody] VetDto VetDto)
        {
            if (VetDto == null)
                return NotFound();

            var Vet = this.mapper.Map<Vet>(VetDto);
            _unitOfWork.Vets.Update(Vet);
            await _unitOfWork.SaveAsync();
            return VetDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Vet = await _unitOfWork.Vets.GetByIdAsync(id);
            if (Vet == null)
                return NotFound();

            _unitOfWork.Vets.Remove(Vet);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}