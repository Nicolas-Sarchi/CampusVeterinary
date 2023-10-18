using Domain.Entities;
namespace Domain.Interfaces;

public interface IPet : IGenericRepository<Pet>
{

    public Task<IEnumerable<Pet>> FelinePets();
    public Task<IEnumerable<Pet>> VaccinationAppointment2023();
    public Task<IEnumerable<IGrouping<Species, Pet>>> PetsBySpecies();
}