using ISTCOSA.Application.Common.Mapping;
using ISTCOSA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class BatchDTO : IMapping<Domain.Entities.Batch>
    {
        public int BatchId { get; set; }
        public int BatchNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
