using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MedicinePurchaseRepository : GenericRepository<MedicinePurchase>, IMedicinePurchase
    {
        private readonly VeterinaryDBContext _context;
        public MedicinePurchaseRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<MedicinePurchase>> GetAllAsync()
        {
            return await _context.MedicinePurchases.ToListAsync();
        }

    }
}