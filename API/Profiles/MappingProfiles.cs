using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles:  Profile
    {
        public MappingProfiles(){
            CreateMap<Species, SpeciesDto>().ReverseMap();
            CreateMap<Species, SpecieswithBreedDto>().ReverseMap();
            CreateMap<Breed, BreedDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();

        }
    }
}