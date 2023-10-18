using Domain.Entities;
namespace Domain.Interfaces;

public interface IBreed : IGenericRepository<Breed>
{
    public  Task<IEnumerable<Object>> PetsPerBreed();
}