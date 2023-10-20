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
    public class VetController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VetController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [ApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VetDto>>> Get()
        {
            var Vet = await _unitOfWork.Vets.GetAllAsync();
            return _mapper.Map<List<VetDto>>(Vet);
        }

        [HttpGet("Specialization/Vascular-Surgeon")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VetDto>>> GetVascularSurgeonVets()
        {
            var Vet = await _unitOfWork.Vets.VascularSurgeonVets();
            return _mapper.Map<List<VetDto>>(Vet);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VetDto>> Get(int id)
        {
            var Vet = await _unitOfWork.Vets.GetByIdAsync(id);
            return _mapper.Map<VetDto>(Vet);
        }
        [ApiVersion("1.1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VetDto>>> Get([FromQuery] Params VetParams)
        {
            var Vet = await _unitOfWork.Vets.GetAllAsync(VetParams.PageIndex, VetParams.PageSize, VetParams.Search, "Name");
            var listaVetsDto = _mapper.Map<List<VetDto>>(Vet.registros);
            return new Pager<VetDto>(listaVetsDto, Vet.totalRegistros, VetParams.PageIndex, VetParams.PageSize, VetParams.Search);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Vet>> Post(VetDto VetDto)
        {
            var Vet = _mapper.Map<Vet>(VetDto);
            _unitOfWork.Vets.Add(Vet);
            await _unitOfWork.SaveAsync();

            if (Vet == null)
            {
                return BadRequest();
            }
            VetDto.Id = Vet.Id;
            return CreatedAtAction(nameof(Post), new { id = VetDto.Id }, Vet);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VetDto>> Put(int id, [FromBody] VetDto VetDto)
        {
            if (VetDto == null)
            {
                return NotFound();
            }
            var Vet = _mapper.Map<Vet>(VetDto);
            _unitOfWork.Vets.Update(Vet);
            await _unitOfWork.SaveAsync();
            return VetDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VetDto>> Delete(int id)
        {
            var Vet = await _unitOfWork.Vets.GetByIdAsync(id);
            if (Vet == null)
            {
                return NotFound();
            }
            _unitOfWork.Vets.Remove(Vet);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}