using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRole
    {
     private readonly VeterinaryDBContext _context;
        public RoleRepository(VeterinaryDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Role>> GetAllAsync()
{
 return await _context.Roles.ToListAsync();
}  
}
}