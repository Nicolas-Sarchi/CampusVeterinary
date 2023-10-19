using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class SaleDetailDto
    {
          public int Quantity { get; set; }
        public int MedicineIdFk { get; set; }
        public double Subtotal { get; set; }
    }
}