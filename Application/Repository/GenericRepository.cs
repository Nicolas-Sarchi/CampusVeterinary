using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly VeterinaryDBContext _context;

        public GenericRepository(VeterinaryDBContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>()
                .Update(entity);
        }
 public async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search, string Nombre)
{
    var query = _context.Set<T>().AsQueryable();
    var totalRegistros = 0;
    List<T> registros = new List<T>();

    if (!string.IsNullOrEmpty(search))
    {
        var propertyType = _context.Model.FindEntityType(typeof(T)).FindProperty(Nombre).ClrType;

        int.TryParse(search, out var searchInt);
        long.TryParse(search, out var searchLong);
        DateTime.TryParse(search, out var searchDate);
        TimeSpan.TryParse(search, out var searchTime);

        query = query.Where(p => 
            (propertyType == typeof(string) && EF.Property<string>(p, Nombre).ToLower().Contains(search.ToLower())) ||
            (propertyType == typeof(int) && EF.Property<int>(p, Nombre) == searchInt) ||
            (propertyType == typeof(long) && EF.Property<long>(p, Nombre) == searchLong) ||
            (propertyType == typeof(DateTime) && EF.Property<DateTime>(p, Nombre).Date == searchDate.Date) ||
            (propertyType == typeof(TimeSpan) && EF.Property<TimeSpan>(p, Nombre) == searchTime)
            // Añade aquí más condiciones para otros tipos de datos si es necesario
        );

        totalRegistros = await query.CountAsync();
        if (totalRegistros > 0)
        {
            registros = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        }
    }
    else
    {
        query = query.OrderBy(p => EF.Property<int>(p, "Id"));
        totalRegistros = await query.CountAsync();
        registros = await query
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
    }

    return (totalRegistros, registros);
}



    }
}