using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PetDto
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int OwnerIdFk {get;set;}
        public int BreedIdFk { get; set; }
        public DateOnly BirthDate { get; set; }

    }
}