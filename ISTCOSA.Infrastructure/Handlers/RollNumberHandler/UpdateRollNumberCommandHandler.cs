using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.RollNumbers.Commands.UpdateRollNumber;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.RollNumberHandler
{
    public class UpdateRollNumberCommandHandler : IRequestHandler<UpdateRollNumberCommand, RollNumberDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UpdateRollNumberCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RollNumberDTO> Handle(UpdateRollNumberCommand request, CancellationToken cancellationToken)
        {
            var existingBatch = await _context.rollNumbers.FindAsync(request.RollNumberId);
            if (existingBatch == null) throw new Exception("RollNumber Not Found");
            existingBatch.RollNumbers = request.RollNumbers;
            existingBatch.BatchId = request.BatchId;
            existingBatch.UpdatedDate = DateTime.Now;
            _context.Update(existingBatch);
            await _context.SaveChangesAsync();
            var mappedBatchforUpdate = _mapper.Map<RollNumberDTO>(existingBatch);
            return mappedBatchforUpdate;
        }
    }
}
