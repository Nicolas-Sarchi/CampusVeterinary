using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class AppointmentController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AppointmentController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> Get()
        {
            var Appointment = await _unitOfWork.Appointments.GetAllAsync();
            return mapper.Map<List<AppointmentDto>>(Appointment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Appointment>> Post(AppointmentDto AppointmentDto)
        {
            var Appointment = this.mapper.Map<Appointment>(AppointmentDto);
            _unitOfWork.Appointments.Add(Appointment);
            await _unitOfWork.SaveAsync();

            if (Appointment == null)
            {
                return BadRequest();
            }
            AppointmentDto.Id = Appointment.Id;
            return CreatedAtAction(nameof(Post), new { id = AppointmentDto.Id }, Appointment);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppointmentDto>> Get(int id)
        {
            var Appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            return mapper.Map<AppointmentDto>(Appointment);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppointmentDto>> Put(int id, [FromBody] AppointmentDto AppointmentDto)
        {
            if (AppointmentDto == null)
                return NotFound();

            var Appointment = this.mapper.Map<Appointment>(AppointmentDto);
            _unitOfWork.Appointments.Update(Appointment);
            await _unitOfWork.SaveAsync();
            return AppointmentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            if (Appointment == null)
                return NotFound();

            _unitOfWork.Appointments.Remove(Appointment);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}