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
public class SupplierController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public SupplierController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<SupplierDto>>> Get()
{
    var Supplier = await _unitOfWork.Suppliers.GetAllAsync();
    return _mapper.Map<List<SupplierDto>>(Supplier);
}

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<SupplierDto>> Get(int id)
{
    var Supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
    return _mapper.Map<SupplierDto>(Supplier);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<SupplierDto>>> Get([FromQuery]Params SupplierParams)
{
var Supplier = await _unitOfWork.Suppliers.GetAllAsync(SupplierParams.PageIndex,SupplierParams.PageSize, SupplierParams.Search, "Name" );
var listaSuppliersDto= _mapper.Map<List<SupplierDto>>(Supplier.registros);
return new Pager<SupplierDto>(listaSuppliersDto, Supplier.totalRegistros,SupplierParams.PageIndex,SupplierParams.PageSize,SupplierParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Supplier>> Post(SupplierDto SupplierDto)
{
    var Supplier = _mapper.Map<Supplier>(SupplierDto);
    _unitOfWork.Suppliers.Add(Supplier);
    await _unitOfWork.SaveAsync();

    if (Supplier == null)
    {
        return BadRequest();
    }
    SupplierDto.Id = Supplier.Id;
    return CreatedAtAction(nameof(Post), new { id = SupplierDto.Id }, Supplier);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<SupplierDto>> Put(int id, [FromBody]SupplierDto SupplierDto)
{
    if (SupplierDto == null)
    {
        return NotFound();
    }
    var Supplier = _mapper.Map<Supplier>(SupplierDto);
    _unitOfWork.Suppliers.Update(Supplier);
    await _unitOfWork.SaveAsync();
    return SupplierDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<SupplierDto>> Delete(int id)
{
    var Supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
    if (Supplier == null)
    {
        return NotFound();
    }
    _unitOfWork.Suppliers.Remove(Supplier);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}