using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.RollNumbers.Queries.GetRollNumberById;
using ISTCOSA.Application.RollNumbers.Queries.GetRollNumbers;
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
    public class GetRollNumberByIdQueryHandler :IRequestHandler<GetRollNumberById,List<RollNumberDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetRollNumberByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RollNumberDTO>> Handle(GetRollNumberById request, CancellationToken cancellationToken)
        {
            var ExistingRollNumber = await _context.rollNumbers.Include(x => x.Batch).Where(x => x.BatchId == request.BatchId).ToListAsync();
            if (ExistingRollNumber == null)
            {
                throw new Exception("RollNumber not Found in this Batch");
            }
            var MappedRollNumber = _mapper.Map<List<RollNumberDTO>>(ExistingRollNumber);
            return MappedRollNumber;
        }
    }
}
