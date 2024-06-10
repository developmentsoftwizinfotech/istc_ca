using AutoMapper;
using ISTCOSA.Application.Batches.Commands.UpdateBatch;
using ISTCOSA.Application.Common.DTOs;
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
    public class UpdateBatchCommandHandler : IRequestHandler<UpdateBatchCommand, BatchDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdateBatchCommandHandler(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BatchDTO> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {

            var existingBatch = await _context.batches.FindAsync(request.BatchId);
            if (existingBatch == null) throw new Exception("Batch Not Found");

            existingBatch.BatchNumber = request.BatchNumber;
            existingBatch.UpdatedDate = DateTime.Now;

            _context.Update(existingBatch);
            await _context.SaveChangesAsync();
            var mappedBatchforUpdate = _mapper.Map<BatchDTO>(existingBatch);
            return mappedBatchforUpdate;
        }
    }
}
