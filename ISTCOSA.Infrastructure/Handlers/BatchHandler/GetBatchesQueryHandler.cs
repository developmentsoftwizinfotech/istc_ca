using AutoMapper;
using ISTCOSA.Application.Batch.Queries.GetBatches;
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
    public class GetBatchesQueryHandler : IRequestHandler<GetAllBatchQuery, List<BatchDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetBatchesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BatchDTO>> Handle(GetAllBatchQuery request, CancellationToken cancellationToken)
        {
            var batches = await _context.batches.Where(x => x.IsActive).ToListAsync();
            if (batches == null) throw new Exception("batches not found");
            var MappingBatches = _mapper.Map<List<BatchDTO>>(batches);
            if (MappingBatches == null) throw new Exception("Error in Mapping of Batches");
            return MappingBatches;
        }
    }
}
