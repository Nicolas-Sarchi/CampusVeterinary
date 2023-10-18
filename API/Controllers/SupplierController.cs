using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
namespace API.Controllers
{
public class SupplierController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public SupplierController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<SupplierDto>>> Get()
{
    var Supplier = await _unitOfWork.Suppliers.GetAllAsync();
    return _mapper.Map<List<SupplierDto>>(Supplier);
}

[HttpGet("Sells")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliersSellsXmedicine(string medicineName)
{
    var Supplier = await _unitOfWork.Suppliers.SuppliersSellsXmedicine(medicineName);
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
    Supplier.Id = Supplier.Id;
    return CreatedAtAction(nameof(Post), new { id = Supplier.Id }, Supplier);
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