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
public class MedicineSaleController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public MedicineSaleController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<MedicineSaleDto>>> Get()
{
    var MedicineSale = await _unitOfWork.MedicineSales.GetAllAsync();
    return _mapper.Map<List<MedicineSaleDto>>(MedicineSale);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicineSaleDto>> Get(int id)
{
    var MedicineSale = await _unitOfWork.MedicineSales.GetByIdAsync(id);
    return _mapper.Map<MedicineSaleDto>(MedicineSale);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<MedicineSaleDto>>> Get([FromQuery]Params MedicineSaleParams)
{
var MedicineSale = await _unitOfWork.MedicineSales.GetAllAsync(MedicineSaleParams.PageIndex,MedicineSaleParams.PageSize, MedicineSaleParams.Search, "id" );
var listaMedicineSalesDto= _mapper.Map<List<MedicineSaleDto>>(MedicineSale.registros);
return new Pager<MedicineSaleDto>(listaMedicineSalesDto, MedicineSale.totalRegistros,MedicineSaleParams.PageIndex,MedicineSaleParams.PageSize,MedicineSaleParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicineSale>> Post(MedicineSaleDto MedicineSaleDto)
{
    var MedicineSale = _mapper.Map<MedicineSale>(MedicineSaleDto);
    _unitOfWork.MedicineSales.Add(MedicineSale);
    await _unitOfWork.SaveAsync();

    if (MedicineSale == null)
    {
        return BadRequest();
    }
    MedicineSaleDto.Id = MedicineSale.Id;
    return CreatedAtAction(nameof(Post), new { id = MedicineSaleDto.Id }, MedicineSale);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicineSaleDto>> Put(int id, [FromBody]MedicineSaleDto MedicineSaleDto)
{
    if (MedicineSaleDto == null)
    {
        return NotFound();
    }
    var MedicineSale = _mapper.Map<MedicineSale>(MedicineSaleDto);
    _unitOfWork.MedicineSales.Update(MedicineSale);
    await _unitOfWork.SaveAsync();
    return MedicineSaleDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicineSaleDto>> Delete(int id)
{
    var MedicineSale = await _unitOfWork.MedicineSales.GetByIdAsync(id);
    if (MedicineSale == null)
    {
        return NotFound();
    }
    _unitOfWork.MedicineSales.Remove(MedicineSale);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}