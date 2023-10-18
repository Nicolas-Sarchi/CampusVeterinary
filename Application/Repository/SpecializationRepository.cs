using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class SpecializationRepository : GenericRepository<Specialization>, ISpecialization
    {
        private readonly VeterinaryDBContext _context;
        public SpecializationRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Specialization>> GetAllAsync()
        {
            return await _context.Specializations.Include(s => s.Vets).ToListAsync();
        }
    }
}