using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MedicinePurchaseDto
    {
        public int Id {get;set;}
        public DateOnly Date { get; set; }
    }
}