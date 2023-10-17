using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medicine : BaseEntity
    {
        public string Name {get;set;}
        public int Stock { get; set; }
        public double Price { get; set; }
        public int LaboratoryIdFk { get; set; }
        public Laboratory Laboratory {get;set;}
        public ICollection<MedicalTreatment> MedicalTreatments {get;set;}
        public ICollection<PurchaseDetail> PurchaseDetails {get;set;}
        public ICollection<SaleDetail> SaleDetails {get;set;}

    }
}