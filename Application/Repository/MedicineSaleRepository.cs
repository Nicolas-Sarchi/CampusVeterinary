using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MedicineSaleRepository : GenericRepository<MedicineSale>, IMedicineSale
    {
     private readonly VeterinaryDBContext _context;
        public MedicineSaleRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<MedicineSale>> GetAllAsync()
{
 return await _context.MedicineSales.ToListAsync();
}  
}
}