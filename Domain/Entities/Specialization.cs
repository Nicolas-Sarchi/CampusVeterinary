using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Specialization : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Vet> Vets { get; set; }
    }
}