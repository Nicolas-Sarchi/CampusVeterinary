using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class BreedRepository : GenericRepository<Breed>, IBreed
    {
     private readonly VeterinaryDBContext _context;
        public BreedRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Breed>> GetAllAsync()
{
 return await _context.Breeds.ToListAsync();
}  
}
}