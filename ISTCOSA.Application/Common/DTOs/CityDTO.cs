using ISTCOSA.Application.Common.Mapping;
using ISTCOSA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class CityDTO:IMapping<Domain.Entities.City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public StateDTO? State { get; set; }
    }
}
