using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PurchaseDetailRepository : GenericRepository<PurchaseDetail>, IPurchaseDetail
    {
     private readonly VeterinaryDBContext _context;
        public PurchaseDetailRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<PurchaseDetail>> GetAllAsync()
{
 return await _context.PurchaseDetails.ToListAsync();
}  
}
}