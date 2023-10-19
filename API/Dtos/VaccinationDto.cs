using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VaccinationDto
    {
         public int Id {get;set;}
        public string Name {get;set;}
        public string OwnerName {get;set;}
        public string Breed { get; set; }
        public DateOnly BirthDate { get; set; }
        public List<AppointmentDto> Appointments {get;set;}
    }
}