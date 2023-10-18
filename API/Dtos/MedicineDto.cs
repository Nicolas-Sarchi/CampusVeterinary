using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MedicineDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int Stock { get; set; }
        public double Price { get; set; }
        public LaboratoryDto Laboratory {get;set;}
    }
}