using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Species, SpeciesDto>().ReverseMap();
            CreateMap<Species, SpecieswithBreedDto>().ReverseMap();
            CreateMap<Breed, BreedDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, AppointmentWithVetDto>().ReverseMap();


            CreateMap<Pet, PetDto>()
            .ForMember(d => d.OwnerName, o => o.MapFrom(s => s.Owner.Name))
            .ForMember(d => d.Breed, o => o.MapFrom(s => s.Breed.Name));
            CreateMap<Pet, AttendedByDto>()
            .ForMember(d => d.OwnerName, o => o.MapFrom(s => s.Owner.Name))
            .ForMember(d => d.Breed, o => o.MapFrom(s => s.Breed.Name));

            CreateMap<Pet, VaccinationDto>()
            .ForMember(d => d.OwnerName, o => o.MapFrom(s => s.Owner.Name))
            .ForMember(d => d.Breed, o => o.MapFrom(s => s.Breed.Name));
            CreateMap<IGrouping<Species, Pet>, SpeciesGroupDto>()
           .ForMember(dest => dest.SpeciesName, opt => opt.MapFrom(src => src.Key.Name))
           .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src));
          
            CreateMap<Vet, VetDto>().ReverseMap();
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
             CreateMap<Medicine, MedicineDto>().ReverseMap();
            CreateMap<Laboratory, LaboratoryDto>().ReverseMap();
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Medicine, MedicineMovementDto>().ReverseMap();
            CreateMap<PurchaseDetail, PurchaseDetailDto>().ReverseMap();
            CreateMap<SaleDetail, SaleDetailDto>().ReverseMap();



            




               
        }
    }
}