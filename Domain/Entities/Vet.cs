using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vet : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SpecializationIdFk {get;set;}
        public Specialization Specialization { get; set; }
        public ICollection<Appointment> Appointments {get;set;}
    }
}