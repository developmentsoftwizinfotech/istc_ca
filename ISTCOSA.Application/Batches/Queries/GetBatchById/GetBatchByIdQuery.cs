using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Batches.Queries.GetBatchById
{
    public class GetBatchByIdQuery:IRequest<BatchDTO>
    {
        public int BatchId { get; set; }
    }
}
