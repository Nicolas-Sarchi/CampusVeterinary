using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class MedicineController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public MedicineController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicineDto>>> Get()
        {
            var Medicine = await _unitOfWork.Medicines.GetAllAsync();
            return mapper.Map<List<MedicineDto>>(Medicine);
        }

        [HttpGet("Laboratory/Genfar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicineDto>>> GetGenfarMedicines()
        {
            var Medicine = await _unitOfWork.Medicines.GenfarMedicines();
            return mapper.Map<List<MedicineDto>>(Medicine);
        }

        [HttpGet("GreaterThan5Thousand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicineDto>>> GreaterThan50Thousand()
        {
            var Medicine = await _unitOfWork.Medicines.MedicinesGreaterThan5thousand();
            return mapper.Map<List<MedicineDto>>(Medicine);
        }

        [HttpGet("Movements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicineMovementDto>>> MedicineMovements()
        {
            var Medicine = await _unitOfWork.Medicines.MedicineMovements();
            return mapper.Map<List<MedicineMovementDto>>(Medicine);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Medicine>> Post(MedicineDto MedicineDto)
        {
            var Medicine = this.mapper.Map<Medicine>(MedicineDto);
            _unitOfWork.Medicines.Add(Medicine);
            await _unitOfWork.SaveAsync();

            if (Medicine == null)
            {
                return BadRequest();
            }
            MedicineDto.Id = Medicine.Id;
            return CreatedAtAction(nameof(Post), new { id = MedicineDto.Id }, Medicine);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicineDto>> Get(int id)
        {
            var Medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
            return mapper.Map<MedicineDto>(Medicine);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicineDto>> Put(int id, [FromBody] MedicineDto MedicineDto)
        {
            if (MedicineDto == null)
                return NotFound();

            var Medicine = this.mapper.Map<Medicine>(MedicineDto);
            _unitOfWork.Medicines.Update(Medicine);
            await _unitOfWork.SaveAsync();
            return MedicineDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
            if (Medicine == null)
                return NotFound();

            _unitOfWork.Medicines.Remove(Medicine);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}