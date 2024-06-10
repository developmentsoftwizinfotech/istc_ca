using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.RollNumbers.Commands.CreateRollNumber;
using ISTCOSA.Domain.Entities;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.RollNumberHandler
{
    public class CreateRollNumberCommandHandler : IRequestHandler<CreateRollNumberCommand, RollNumberDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateRollNumberCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RollNumberDTO> Handle(CreateRollNumberCommand request, CancellationToken cancellationToken)
        {
            var existingBatchId = await _context.batches.FindAsync(request.BatchId);
            if (existingBatchId == null) throw new Exception("BatchId doesn't exist");
            var ExistingRollNumber =await _context.rollNumbers.FirstOrDefaultAsync(x=>x.RollNumbers==request.RollNumbers);
            if (ExistingRollNumber != null) throw new Exception("RollNumber is already exist");

            var RollNumbers = new RollNumber()
            {
                RollNumbers = request.RollNumbers,
                BatchId = request.BatchId,
                CreatedDate = DateTime.Now,
                IsActive = true,
            };

            await _context.AddAsync(RollNumbers);
            var result = _mapper.Map<RollNumberDTO>(RollNumbers);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
