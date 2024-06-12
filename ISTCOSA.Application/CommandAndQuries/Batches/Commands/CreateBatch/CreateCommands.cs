
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Batches.Commands.CreateBatch
{
    public class CreateCommands : IRequest<BatchDTO>
    {
        public int BatchId { get; set; }
        public int BatchNumber { get; set; }


    }
}
