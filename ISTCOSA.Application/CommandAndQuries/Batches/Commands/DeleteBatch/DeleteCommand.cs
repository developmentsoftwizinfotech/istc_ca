using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Batches.Commands.DeleteBatch
{
    public class DeleteCommand : IRequest<BatchDTO>
    {
        public int BatchId { get; set; }
    }
}
