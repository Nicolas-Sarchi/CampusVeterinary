using Domain.Entities;
namespace Domain.Interfaces;

public interface ISupplier : IGenericRepository<Supplier>
{
    public Task<IEnumerable<Supplier>> SuppliersSellsXmedicine(string medicineName);
}