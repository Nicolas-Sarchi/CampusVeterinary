using Domain.Entities;
namespace Domain.Interfaces;

public interface IMedicine : IGenericRepository<Medicine>
{
    public Task<IEnumerable<Medicine>> GenfarMedicines();
    public Task<IEnumerable<Medicine>> MedicinesGreaterThan5thousand();
    public Task<IEnumerable<Medicine>> MedicineMovements();
}