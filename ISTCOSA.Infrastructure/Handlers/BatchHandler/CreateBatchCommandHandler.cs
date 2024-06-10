using AutoMapper;
using ISTCOSA.Application.Batch.Commands.CreateBatch;
using ISTCOSA.Application.Batch.Queries.GetBatches;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Domain.Entities;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.BatchHandler
{
    public class CreateBatchCommandHandler : IRequestHandler<CreateCommands, BatchDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateBatchCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BatchDTO> Handle(CreateCommands request, CancellationToken cancellationToken)
        {
            var existingBatch = await _context.batches.FirstOrDefaultAsync(x => x.BatchNumber == request.BatchNumber);
            if (existingBatch != null) throw new Exception("Batch Number is Already Saved");
            var batchList = new Batch()
            {
                BatchNumber = request.BatchNumber,
                CreatedDate = DateTime.Now,
                IsActive = true,
            };

            await _context.AddAsync(batchList);
            var result = _mapper.Map<BatchDTO>(batchList);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
