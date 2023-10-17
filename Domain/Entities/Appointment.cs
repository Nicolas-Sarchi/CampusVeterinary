using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int PetIdFk {get;set;}
        public Pet Pet {get;set;}
        public DateOnly Date {get;set;}
        public TimeOnly Time { get; set; }
        public string Reason { get; set; }
        public int VetIdFk { get; set; }
        public Vet Vet { get; set; }
        public ICollection<MedicalTreatment> MedicalTreatments {get;set;}

    }
}