using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicineSale : BaseEntity
    {
        public DateOnly Date { get; set; }
        public double Total {get;set;}
        public ICollection<SaleDetail> SaleDetails {get;set;}
         public int OwnerIdFk { get; set; }
        public Owner Owner { get; set; }
        
    }
}