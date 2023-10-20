using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
namespace API.Controllers
{
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]
public class LaboratoryController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public LaboratoryController(IUnitOfWork UnitOfWork, IMapper Mapper)

{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<LaboratoryDto>>> Get()
{
    var Laboratory = await _unitOfWork.Laboratories.GetAllAsync();
    return _mapper.Map<List<LaboratoryDto>>(Laboratory);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<LaboratoryDto>> Get(int id)
{
    var Laboratory = await _unitOfWork.Laboratories.GetByIdAsync(id);
    return _mapper.Map<LaboratoryDto>(Laboratory);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<LaboratoryDto>>> Get([FromQuery]Params LaboratoryParams)
{
var Laboratory = await _unitOfWork.Laboratories.GetAllAsync(LaboratoryParams.PageIndex,LaboratoryParams.PageSize, LaboratoryParams.Search, "Name");
var listaLaboratoriesDto= _mapper.Map<List<LaboratoryDto>>(Laboratory.registros);
return new Pager<LaboratoryDto>(listaLaboratoriesDto, Laboratory.totalRegistros,LaboratoryParams.PageIndex,LaboratoryParams.PageSize,LaboratoryParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Laboratory>> Post(LaboratoryDto LaboratoryDto)
{
    var Laboratory = _mapper.Map<Laboratory>(LaboratoryDto);
    _unitOfWork.Laboratories.Add(Laboratory);
    await _unitOfWork.SaveAsync();

    if (Laboratory == null)
    {
        return BadRequest();
    }
    LaboratoryDto.Id = Laboratory.Id;
    return CreatedAtAction(nameof(Post), new { id = LaboratoryDto.Id }, Laboratory);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<LaboratoryDto>> Put(int id, [FromBody]LaboratoryDto LaboratoryDto)
{
    if (LaboratoryDto == null)
    {
        return NotFound();
    }
    var Laboratory = _mapper.Map<Laboratory>(LaboratoryDto);
    _unitOfWork.Laboratories.Update(Laboratory);
    await _unitOfWork.SaveAsync();
    return LaboratoryDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<LaboratoryDto>> Delete(int id)
{
    var Laboratory = await _unitOfWork.Laboratories.GetByIdAsync(id);
    if (Laboratory == null)
    {
        return NotFound();
    }
    _unitOfWork.Laboratories.Remove(Laboratory);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}