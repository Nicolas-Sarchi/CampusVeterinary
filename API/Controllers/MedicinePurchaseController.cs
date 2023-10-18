using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
namespace API.Controllers
{
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class MedicinePurchaseController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public MedicinePurchaseController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<MedicinePurchaseDto>>> Get()
{
    var MedicinePurchase = await _unitOfWork.MedicinePurchases.GetAllAsync();
    return _mapper.Map<List<MedicinePurchaseDto>>(MedicinePurchase);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicinePurchaseDto>> Get(int id)
{
    var MedicinePurchase = await _unitOfWork.MedicinePurchases.GetByIdAsync(id);
    return _mapper.Map<MedicinePurchaseDto>(MedicinePurchase);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<MedicinePurchaseDto>>> Get([FromQuery]Params MedicinePurchaseParams)
{
var MedicinePurchase = await _unitOfWork.MedicinePurchases.GetAllAsync(MedicinePurchaseParams.PageIndex,MedicinePurchaseParams.PageSize, MedicinePurchaseParams.Search, "id");
var listaMedicinePurchasesDto= _mapper.Map<List<MedicinePurchaseDto>>(MedicinePurchase.registros);
return new Pager<MedicinePurchaseDto>(listaMedicinePurchasesDto, MedicinePurchase.totalRegistros,MedicinePurchaseParams.PageIndex,MedicinePurchaseParams.PageSize,MedicinePurchaseParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicinePurchase>> Post(MedicinePurchaseDto MedicinePurchaseDto)
{
    var MedicinePurchase = _mapper.Map<MedicinePurchase>(MedicinePurchaseDto);
    _unitOfWork.MedicinePurchases.Add(MedicinePurchase);
    await _unitOfWork.SaveAsync();

    if (MedicinePurchase == null)
    {
        return BadRequest();
    }
    MedicinePurchase.Id = MedicinePurchase.Id;
    return CreatedAtAction(nameof(Post), new { id = MedicinePurchase.Id }, MedicinePurchase);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicinePurchaseDto>> Put(int id, [FromBody]MedicinePurchaseDto MedicinePurchaseDto)
{
    if (MedicinePurchaseDto == null)
    {
        return NotFound();
    }
    var MedicinePurchase = _mapper.Map<MedicinePurchase>(MedicinePurchaseDto);
    _unitOfWork.MedicinePurchases.Update(MedicinePurchase);
    await _unitOfWork.SaveAsync();
    return MedicinePurchaseDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicinePurchaseDto>> Delete(int id)
{
    var MedicinePurchase = await _unitOfWork.MedicinePurchases.GetByIdAsync(id);
    if (MedicinePurchase == null)
    {
        return NotFound();
    }
    _unitOfWork.MedicinePurchases.Remove(MedicinePurchase);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}