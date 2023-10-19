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
public class OwnerController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public OwnerController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<OwnerDto>>> Get()
{
    var Owner = await _unitOfWork.Owners.GetAllAsync();
    return _mapper.Map<List<OwnerDto>>(Owner);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<OwnerDto>> Get(int id)
{
    var Owner = await _unitOfWork.Owners.GetByIdAsync(id);
    return _mapper.Map<OwnerDto>(Owner);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<OwnerDto>>> Get([FromQuery]Params OwnerParams)
{
var Owner = await _unitOfWork.Owners.GetAllAsync(OwnerParams.PageIndex,OwnerParams.PageSize, OwnerParams.Search, "" , typeof(string));
var listaOwnersDto= _mapper.Map<List<OwnerDto>>(Owner.registros);
return new Pager<OwnerDto>(listaOwnersDto, Owner.totalRegistros,OwnerParams.PageIndex,OwnerParams.PageSize,OwnerParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Owner>> Post(OwnerDto OwnerDto)
{
    var Owner = _mapper.Map<Owner>(OwnerDto);
    _unitOfWork.Owners.Add(Owner);
    await _unitOfWork.SaveAsync();

    if (Owner == null)
    {
        return BadRequest();
    }
    OwnerDto.Id = Owner.Id;
    return CreatedAtAction(nameof(Post), new { id = OwnerDto.Id }, Owner);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<OwnerDto>> Put(int id, [FromBody]OwnerDto OwnerDto)
{
    if (OwnerDto == null)
    {
        return NotFound();
    }
    var Owner = _mapper.Map<Owner>(OwnerDto);
    _unitOfWork.Owners.Update(Owner);
    await _unitOfWork.SaveAsync();
    return OwnerDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<OwnerDto>> Delete(int id)
{
    var Owner = await _unitOfWork.Owners.GetByIdAsync(id);
    if (Owner == null)
    {
        return NotFound();
    }
    _unitOfWork.Owners.Remove(Owner);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}