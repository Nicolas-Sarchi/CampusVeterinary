using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MedicalTreatmentRepository : GenericRepository<MedicalTreatment>, IMedicalTreatment
    {
     private readonly VeterinaryDBContext _context;
        public MedicalTreatmentRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<MedicalTreatment>> GetAllAsync()
{
 return await _context.MedicalTreatments.ToListAsync();
}  
}
}