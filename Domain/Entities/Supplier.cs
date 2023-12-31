using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Address {get;set;}
        public string Phone { get; set; }
        public ICollection<MedicinePurchase> MedicinePurchases {get;set;}
    }
}