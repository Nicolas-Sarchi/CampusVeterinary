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
            return await _context.Medicines.Include(m => m.Laboratory).ToListAsync();
        }

        public async Task<IEnumerable<Medicine>> GenfarMedicines()
        {
            return await _context.Medicines.Where(m => m.LaboratoryIdFk == 1).Include(m => m.Laboratory).ToListAsync();
        }

         public async Task<IEnumerable<Medicine>> MedicinesGreaterThan5thousand()
         {
            return await _context.Medicines.Where(m => m.Price > 50000).Include(m => m.Laboratory).ToListAsync();
         }

         public async Task<IEnumerable<Medicine>> MedicineMovements()
         {
            return await _context.Medicines.Include(m => m.PurchaseDetails).Include(m => m.SaleDetails).ToListAsync();
         }

         
    }
}