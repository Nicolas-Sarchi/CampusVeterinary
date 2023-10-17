using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SaleDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public int IdMedicineSaleFk { get; set; }
        public MedicineSale MedicineSale { get; set; }
        public int MedicineIdFk { get; set; }
        public Medicine Medicine { get; set; }
        public double Subtotal {get;set;}
    }
}