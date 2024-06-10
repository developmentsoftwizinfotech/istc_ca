using ISTCOSA.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class CountryDTO:IMapping<Domain.Entities.Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
