using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
namespace API.Controllers
{
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]
public class AppointmentController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public AppointmentController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<AppointmentDto>>> Get()
{
    var Appointment = await _unitOfWork.Appointments.GetAllAsync();
    return _mapper.Map<List<AppointmentDto>>(Appointment);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<AppointmentDto>> Get(int id)
{
    var Appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
    return _mapper.Map<AppointmentDto>(Appointment);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<AppointmentDto>>> Get([FromQuery]Params AppointmentParams)
{
var Appointment = await _unitOfWork.Appointments.GetAllAsync(AppointmentParams.PageIndex,AppointmentParams.PageSize, AppointmentParams.Search,  "id");
var listaAppointmentsDto= _mapper.Map<List<AppointmentDto>>(Appointment.registros);
return new Pager<AppointmentDto>(listaAppointmentsDto, Appointment.totalRegistros,AppointmentParams.PageIndex,AppointmentParams.PageSize,AppointmentParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Appointment>> Post(AppointmentDto AppointmentDto)
{
    var Appointment = _mapper.Map<Appointment>(AppointmentDto);
    _unitOfWork.Appointments.Add(Appointment);
    await _unitOfWork.SaveAsync();

    if (Appointment == null)
    {
        return BadRequest();
    }
    AppointmentDto.Id = Appointment.Id;
    return CreatedAtAction(nameof(Post), new { id = AppointmentDto.Id }, Appointment);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<AppointmentDto>> Put(int id, [FromBody]AppointmentDto AppointmentDto)
{
    if (AppointmentDto == null)
    {
        return NotFound();
    }
    var Appointment = _mapper.Map<Appointment>(AppointmentDto);
    _unitOfWork.Appointments.Update(Appointment);
    await _unitOfWork.SaveAsync();
    return AppointmentDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<AppointmentDto>> Delete(int id)
{
    var Appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
    if (Appointment == null)
    {
        return NotFound();
    }
    _unitOfWork.Appointments.Remove(Appointment);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}