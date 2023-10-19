using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class OwnerRepository : GenericRepository<Owner>, IOwner
    {
        private readonly VeterinaryDBContext _context;
        public OwnerRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners.Include(o => o.Pets).ThenInclude(p => p.Breed).ToListAsync();
        }

        
    }
}