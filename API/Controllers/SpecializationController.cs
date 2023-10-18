using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class SpecializationController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public SpecializationController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<SpecializationDto>>> Get()
        {
            var Specialization = await _unitOfWork.Specializations.GetAllAsync();
            return mapper.Map<List<SpecializationDto>>(Specialization);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Specialization>> Post(SpecializationDto SpecializationDto)
        {
            var Specialization = this.mapper.Map<Specialization>(SpecializationDto);
            _unitOfWork.Specializations.Add(Specialization);
            await _unitOfWork.SaveAsync();

            if (Specialization == null)
            {
                return BadRequest();
            }
            SpecializationDto.Id = Specialization.Id;
            return CreatedAtAction(nameof(Post), new { id = SpecializationDto.Id }, Specialization);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SpecializationDto>> Get(int id)
        {
            var Specialization = await _unitOfWork.Specializations.GetByIdAsync(id);
            return mapper.Map<SpecializationDto>(Specialization);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SpecializationDto>> Put(int id, [FromBody] SpecializationDto SpecializationDto)
        {
            if (SpecializationDto == null)
                return NotFound();

            var Specialization = this.mapper.Map<Specialization>(SpecializationDto);
            _unitOfWork.Specializations.Update(Specialization);
            await _unitOfWork.SaveAsync();
            return SpecializationDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Specialization = await _unitOfWork.Specializations.GetByIdAsync(id);
            if (Specialization == null)
                return NotFound();

            _unitOfWork.Specializations.Remove(Specialization);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}