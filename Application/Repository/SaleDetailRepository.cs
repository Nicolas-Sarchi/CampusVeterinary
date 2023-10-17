using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class SaleDetailRepository : GenericRepository<SaleDetail>, ISaleDetail
    {
     private readonly VeterinaryDBContext _context;
        public SaleDetailRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<SaleDetail>> GetAllAsync()
{
 return await _context.SaleDetails.ToListAsync();
}  
}
}