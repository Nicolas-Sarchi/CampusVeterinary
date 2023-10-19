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
public class MedicineController : BaseApiController
{
private IUnitOfWork _unitOfWork;
private readonly IMapper _mapper;
 public MedicineController(IUnitOfWork UnitOfWork, IMapper Mapper)
{
 _unitOfWork = UnitOfWork;
 _mapper = Mapper;
}
[ApiVersion("1.0")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<MedicineDto>>> Get()
{
    var Medicine = await _unitOfWork.Medicines.GetAllAsync();
    return _mapper.Map<List<MedicineDto>>(Medicine);
}

  [HttpGet("Laboratory/Genfar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicineDto>>> GetGenfarMedicines()
        {
            var Medicine = await _unitOfWork.Medicines.GenfarMedicines();
            return _mapper.Map<List<MedicineDto>>(Medicine);
        }

        [HttpGet("GreaterThan5Thousand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicineDto>>> GreaterThan50Thousand()
        {
            var Medicine = await _unitOfWork.Medicines.MedicinesGreaterThan5thousand();
            return _mapper.Map<List<MedicineDto>>(Medicine);
        }

        [HttpGet("Movements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicineMovementDto>>> MedicineMovements()
        {
            var Medicine = await _unitOfWork.Medicines.MedicineMovements();
            return _mapper.Map<List<MedicineMovementDto>>(Medicine);
        }

[HttpGet("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicineDto>> Get(int id)
{
    var Medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
    return _mapper.Map<MedicineDto>(Medicine);
}
[ApiVersion("1.1")]
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Pager<MedicineDto>>> Get([FromQuery]Params MedicineParams)
{
var Medicine = await _unitOfWork.Medicines.GetAllAsync(MedicineParams.PageIndex,MedicineParams.PageSize, MedicineParams.Search, "" , typeof(string));
var listaMedicinesDto= _mapper.Map<List<MedicineDto>>(Medicine.registros);
return new Pager<MedicineDto>(listaMedicinesDto, Medicine.totalRegistros,MedicineParams.PageIndex,MedicineParams.PageSize,MedicineParams.Search);
}

[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<Medicine>> Post(MedicineDto MedicineDto)
{
    var Medicine = _mapper.Map<Medicine>(MedicineDto);
    _unitOfWork.Medicines.Add(Medicine);
    await _unitOfWork.SaveAsync();

    if (Medicine == null)
    {
        return BadRequest();
    }
    MedicineDto.Id = Medicine.Id;
    return CreatedAtAction(nameof(Post), new { id = MedicineDto.Id }, Medicine);
}

[HttpPut("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicineDto>> Put(int id, [FromBody]MedicineDto MedicineDto)
{
    if (MedicineDto == null)
    {
        return NotFound();
    }
    var Medicine = _mapper.Map<Medicine>(MedicineDto);
    _unitOfWork.Medicines.Update(Medicine);
    await _unitOfWork.SaveAsync();
    return MedicineDto;
}

[HttpDelete("{id}")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<MedicineDto>> Delete(int id)
{
    var Medicine = await _unitOfWork.Medicines.GetByIdAsync(id);
    if (Medicine == null)
    {
        return NotFound();
    }
    _unitOfWork.Medicines.Remove(Medicine);
    await _unitOfWork.SaveAsync();
    return NoContent();
}
}
}