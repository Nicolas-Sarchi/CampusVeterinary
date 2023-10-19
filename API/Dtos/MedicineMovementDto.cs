using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class MedicineMovementDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public List<PurchaseDetailDto> PurchaseDetails {get;set;}
        public List<SaleDetailDto> SaleDetails {get;set;}

    }
}