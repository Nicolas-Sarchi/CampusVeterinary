using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MedicineRepository : GenericRepository<Medicine>, IMedicine
    {
     private readonly VeterinaryDBContext _context;
        public MedicineRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Medicine>> GetAllAsync()
{
 return await _context.Medicines.ToListAsync();
}  
}
}