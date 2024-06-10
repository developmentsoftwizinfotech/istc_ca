using AutoMapper;
using ISTCOSA.Application.Batches.Queries.GetBatchById;
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
    public class GetBatchByIdQueryHandler : IRequestHandler<GetBatchByIdQuery, BatchDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetBatchByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BatchDTO> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            var ExistingBatch = await _context.batches.FindAsync(request.BatchId);
            if (ExistingBatch == null)
            {
                throw new Exception("Batch not Found");
            }
            var Mappedbatch = _mapper.Map<BatchDTO>(ExistingBatch);
            return Mappedbatch;
        }
    }
}
