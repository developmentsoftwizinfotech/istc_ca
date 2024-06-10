using ISTCOSA.Application.Common.Mapping;
using ISTCOSA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class RollNumberDTO:IMapping<RollNumber>
    {
        public int RollNumberId { get; set; }
        public int BatchId { get; set; }
        public string BatchNumber { get; set; }
        public int RollNumbers { get; set; }
        
    }
}
