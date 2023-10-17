using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicinePurchase : BaseEntity
    {
        public DateOnly Date { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails {get;set;}
        public double Total {get;set;}
       public int SupplierIdFk { get; set; }
        public Supplier Supplier {get;set;}
    }
}