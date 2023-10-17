using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicalTreatment : BaseEntity
    {
        public int AppointmentIdFk { get; set; }
        public Appointment Appointment { get; set; }
        public int MedicineIdFk { get; set; }
        public Medicine Medicine { get; set; }
        public string Dose { get; set; }
        public DateOnly AdministrationDate { get; set; }
        public string Observation { get; set; }

    }
}