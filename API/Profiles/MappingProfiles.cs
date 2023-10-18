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

            CreateMap<Pet, PetDto>();

            CreateMap<IGrouping<Species, Pet>, SpeciesGroupDto>()
           .ForMember(dest => dest.SpeciesName, opt => opt.MapFrom(src => src.Key.Name))
           .ForMember(dest => dest.Pets, opt => opt.MapFrom(src => src));

            CreateMap<Vet, VetDto>().ReverseMap();
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
             CreateMap<Medicine, MedicineDto>().ReverseMap();
            CreateMap<Laboratory, LaboratoryDto>().ReverseMap();
            CreateMap<Owner, OwnerDto>().ReverseMap();



               
        }
    }
}