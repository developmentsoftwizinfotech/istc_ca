﻿using AutoMapper;
using ISTCOSA.Application.Batches.Commands.DeleteBatch;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.BatchHandler
{
    public class DeleteBatchCommandHandler : IRequestHandler<DeleteCommand, BatchDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeleteBatchCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BatchDTO> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var existingBatch = await _context.batches.FindAsync(request.BatchId);
            if (existingBatch != null)
            {
                existingBatch.IsActive = false;
                existingBatch.DeletedDate = DateTime.Now;
            }
            var mappeddata = _mapper.Map<BatchDTO>(existingBatch);
            await _context.SaveChangesAsync();
            return mappeddata;
        }
    }
}
