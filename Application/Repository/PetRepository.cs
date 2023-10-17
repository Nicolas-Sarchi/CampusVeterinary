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
        public async Task<IEnumerable<Pet>> FelinePets (){
            return await _context.Pets.Where(p => p.BreedIdFk == 2).ToListAsync();
        }

        public async Task<IEnumerable<Pet>> VaccinationAppointment2023 (){
            return await _context.Pets.Where(p => p.Appointments.Any(a => a.Reason == "Vacunacion" && a.Date.Year == 2023 && a.Date.Month <= 3)).ToListAsync();
        }

        

    }
}