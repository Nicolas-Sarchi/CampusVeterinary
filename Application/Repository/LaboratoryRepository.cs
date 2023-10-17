using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratory
    {
     private readonly VeterinaryDBContext _context;
        public LaboratoryRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Laboratory>> GetAllAsync()
{
 return await _context.Laboratories.ToListAsync();
}  
}
}