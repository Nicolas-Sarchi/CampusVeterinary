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

    if (!string.IsNullOrEmpty(search))
    {
        var propertyType = _context.Model.FindEntityType(typeof(T)).FindProperty(Nombre).ClrType;

        if (propertyType == typeof(string))
        {
            query = query.Where(p => EF.Property<string>(p, Nombre).ToLower().Contains(search.ToLower()));
        }
        else if (propertyType == typeof(int) || propertyType == typeof(long))
        {
            if (long.TryParse(search, out var searchLong))
            {
                query = query.Where(p => EF.Property<long>(p, Nombre) == searchLong);
            }
        }
        else if (propertyType == typeof(DateTime))
        {
            if (DateTime.TryParse(search, out var searchDate))
            {
                query = query.Where(p => EF.Property<DateTime>(p, Nombre).Date == searchDate.Date);
            }
        }
        else if (propertyType == typeof(TimeSpan))
        {
            if (TimeSpan.TryParse(search, out var searchTime))
            {
                query = query.Where(p => EF.Property<TimeSpan>(p, Nombre) == searchTime);
            }
        }
        // Añade aquí más condiciones para otros tipos de datos si es necesario
    }

    var totalRegistros = await query.CountAsync();
    var registros = totalRegistros > 0 ? await query
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync() : new List<T>();

    return (totalRegistros, registros);
}




    }
}