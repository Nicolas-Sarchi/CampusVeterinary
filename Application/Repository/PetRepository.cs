using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PetRepository : GenericRepository<Pet>, IPet
    {
     private readonly VeterinaryDBContext _context;
        public PetRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Pet>> GetAllAsync()
{
 return await _context.Pets.ToListAsync();
}  
}
}