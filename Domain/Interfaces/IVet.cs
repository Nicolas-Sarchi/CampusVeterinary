using Domain.Entities;
namespace Domain.Interfaces;

public interface IVet : IGenericRepository<Vet>
{
     public  Task<IEnumerable<Vet>> VascularSurgeonVets ();
}