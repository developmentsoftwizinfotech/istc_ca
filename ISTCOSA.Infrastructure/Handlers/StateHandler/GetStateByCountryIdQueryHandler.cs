using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.State.Queries;
using ISTCOSA.Domain.Entities;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.StateHandler
{
    public class GetStateByCountryIdQueryHandler : IRequestHandler<GetStateByCountryIdQueries, List<StateDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetStateByCountryIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<StateDTO>> Handle(GetStateByCountryIdQueries request, CancellationToken cancellationToken)
        {
            var states = await _context.states.Include(x=>x.Country).Where(x => x.CountryId == request.Id).ToListAsync(cancellationToken);
            if (states == null || states.Count == 0)
            {
                throw new Exception("States not found under this country");
            }

            var MappedData = _mapper.Map<List<StateDTO>>(states);
            if (MappedData == null || MappedData.Count == 0)
            {
                throw new Exception("Mapped data is not found");
            }
            return MappedData;
        }

    }
}
