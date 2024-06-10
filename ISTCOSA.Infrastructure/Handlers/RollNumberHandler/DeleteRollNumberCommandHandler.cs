using AutoMapper;
using ISTCOSA.Application.Batches.Commands.DeleteBatch;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.RollNumbers.Commands.DeleteRollNumber;
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
    public class DeleteRollNumberCommandHandler : IRequestHandler<DeleteRollNumberCommand, RollNumberDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeleteRollNumberCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RollNumberDTO> Handle(DeleteRollNumberCommand request, CancellationToken cancellationToken)
        {
            var existingRollNumber = await _context.rollNumbers.FindAsync(request.RollNumberId);
            if (existingRollNumber != null)
            {
                existingRollNumber.IsActive = false;
                existingRollNumber.DeletedDate = DateTime.Now;
            }
            var mappeddata = _mapper.Map<RollNumberDTO>(existingRollNumber);
            await _context.SaveChangesAsync();
            return mappeddata;
        }
    }
}
