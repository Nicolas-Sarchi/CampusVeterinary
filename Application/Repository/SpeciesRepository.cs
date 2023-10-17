using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class SpeciesRepository : GenericRepository<Species>, ISpecies
    {
     private readonly VeterinaryDBContext _context;
        public SpeciesRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Species>> GetAllAsync()
{
 return await _context.Species.Include(s => s.Breeds).ToListAsync();
}  
}
}