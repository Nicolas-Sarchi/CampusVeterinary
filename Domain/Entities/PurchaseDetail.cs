using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PurchaseDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public int IdMedicinePurchaseFk { get; set; }
        public MedicinePurchase MedicinePurchase { get; set; }
        public int MedicineIdFk { get; set; }
        public Medicine Medicine { get; set; }
        public double Subtotal {get;set;}
    }
}