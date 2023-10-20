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
public class MedicalTreatmentController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public MedicalTreatmentController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<MedicalTreatmentDto>>> Get()
{
    var MedicalTreatment = await _unitOfWork.MedicalTreatments.GetAllAsync();
    return _mapper.Map<List<MedicalTreatmentDto>>(MedicalTreatment);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicalTreatmentDto>> Get(int id)
{
    var MedicalTreatment = await _unitOfWork.MedicalTreatments.GetByIdAsync(id);
    return _mapper.Map<MedicalTreatmentDto>(MedicalTreatment);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<MedicalTreatmentDto>>> Get([FromQuery]Params MedicalTreatmentParams)
{
var MedicalTreatment = await _unitOfWork.MedicalTreatments.GetAllAsync(MedicalTreatmentParams.PageIndex,MedicalTreatmentParams.PageSize, MedicalTreatmentParams.Search, "Date" );
var listaMedicalTreatmentsDto= _mapper.Map<List<MedicalTreatmentDto>>(MedicalTreatment.registros);
return new Pager<MedicalTreatmentDto>(listaMedicalTreatmentsDto, MedicalTreatment.totalRegistros,MedicalTreatmentParams.PageIndex,MedicalTreatmentParams.PageSize,MedicalTreatmentParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicalTreatment>> Post(MedicalTreatmentDto MedicalTreatmentDto)
{
    var MedicalTreatment = _mapper.Map<MedicalTreatment>(MedicalTreatmentDto);
    _unitOfWork.MedicalTreatments.Add(MedicalTreatment);
    await _unitOfWork.SaveAsync();

    if (MedicalTreatment == null)
    {
        return BadRequest();
    }
    MedicalTreatmentDto.Id = MedicalTreatment.Id;
    return CreatedAtAction(nameof(Post), new { id = MedicalTreatmentDto.Id }, MedicalTreatment);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicalTreatmentDto>> Put(int id, [FromBody]MedicalTreatmentDto MedicalTreatmentDto)
{
    if (MedicalTreatmentDto == null)
    {
        return NotFound();
    }
    var MedicalTreatment = _mapper.Map<MedicalTreatment>(MedicalTreatmentDto);
    _unitOfWork.MedicalTreatments.Update(MedicalTreatment);
    await _unitOfWork.SaveAsync();
    return MedicalTreatmentDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicalTreatmentDto>> Delete(int id)
{
    var MedicalTreatment = await _unitOfWork.MedicalTreatments.GetByIdAsync(id);
    if (MedicalTreatment == null)
    {
        return NotFound();
    }
    _unitOfWork.MedicalTreatments.Remove(MedicalTreatment);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}