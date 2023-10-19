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
public class SpecializationController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public SpecializationController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<SpecializationDto>>> Get()
{
    var Specialization = await _unitOfWork.Specializations.GetAllAsync();
    return _mapper.Map<List<SpecializationDto>>(Specialization);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<SpecializationDto>> Get(int id)
{
    var Specialization = await _unitOfWork.Specializations.GetByIdAsync(id);
    return _mapper.Map<SpecializationDto>(Specialization);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<SpecializationDto>>> Get([FromQuery]Params SpecializationParams)
{
var Specialization = await _unitOfWork.Specializations.GetAllAsync(SpecializationParams.PageIndex,SpecializationParams.PageSize, SpecializationParams.Search, "" , typeof(string));
var listaSpecializationsDto= _mapper.Map<List<SpecializationDto>>(Specialization.registros);
return new Pager<SpecializationDto>(listaSpecializationsDto, Specialization.totalRegistros,SpecializationParams.PageIndex,SpecializationParams.PageSize,SpecializationParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Specialization>> Post(SpecializationDto SpecializationDto)
{
    var Specialization = _mapper.Map<Specialization>(SpecializationDto);
    _unitOfWork.Specializations.Add(Specialization);
    await _unitOfWork.SaveAsync();

    if (Specialization == null)
    {
        return BadRequest();
    }
    SpecializationDto.Id = Specialization.Id;
    return CreatedAtAction(nameof(Post), new { id = SpecializationDto.Id }, Specialization);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<SpecializationDto>> Put(int id, [FromBody]SpecializationDto SpecializationDto)
{
    if (SpecializationDto == null)
    {
        return NotFound();
    }
    var Specialization = _mapper.Map<Specialization>(SpecializationDto);
    _unitOfWork.Specializations.Update(Specialization);
    await _unitOfWork.SaveAsync();
    return SpecializationDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<SpecializationDto>> Delete(int id)
{
    var Specialization = await _unitOfWork.Specializations.GetByIdAsync(id);
    if (Specialization == null)
    {
        return NotFound();
    }
    _unitOfWork.Specializations.Remove(Specialization);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}