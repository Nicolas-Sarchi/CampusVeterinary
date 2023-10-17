using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class VetRepository : GenericRepository<Vet>, IVet
    {
        private readonly VeterinaryDBContext _context;
        public VetRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Vet>> GetAllAsync()
        {
            return await _context.Vets.ToListAsync();
        }

        public async Task<IEnumerable<Vet>> VascularSurgeonVets (){

            return await _context.Vets.Where(v => v.SpecializationIdFk == 1).ToListAsync();
        }
    }
}