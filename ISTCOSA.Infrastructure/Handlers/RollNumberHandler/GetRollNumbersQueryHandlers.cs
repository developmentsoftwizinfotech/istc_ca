using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
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
    public class GetRollNumbersQueryHandlers : IRequestHandler<GetAllRollNumbersQuery,List<RollNumberDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetRollNumbersQueryHandlers(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RollNumberDTO>> Handle(GetAllRollNumbersQuery request, CancellationToken cancellationToken)
        {
            var RollNumbers = await _context.rollNumbers.Where(x => x.IsActive).ToListAsync();
            var Mappingdata = _mapper.Map<List<RollNumberDTO>>(RollNumbers);
            return Mappingdata;
        }
    }
}
