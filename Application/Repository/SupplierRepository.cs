using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplier
    {
        private readonly VeterinaryDBContext _context;
        public SupplierRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> SuppliersSellsXmedicine(string medicineName)
        {
            return await _context.Suppliers
            .Where(s => s.MedicinePurchases
            .Any(mp => mp.PurchaseDetails
            .Any(pd => pd.Medicine.Name == medicineName)))
            .ToListAsync();
        }

    }
}