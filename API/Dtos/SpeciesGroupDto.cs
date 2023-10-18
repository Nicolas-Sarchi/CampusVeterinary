using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class SpeciesGroupDto
{
    public string SpeciesName { get; set; }
    public IEnumerable<PetDto> Pets { get; set; }
}

}