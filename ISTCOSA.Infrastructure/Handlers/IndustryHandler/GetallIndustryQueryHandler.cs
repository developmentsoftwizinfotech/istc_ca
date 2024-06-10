using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.Company.Queries;
using ISTCOSA.Application.Industry.Queries;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.IndustryHandler
{
    public class GetallIndustryQueryHandler : IRequestHandler<GetAllIndustriesQuery, List<IndustryDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetallIndustryQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IndustryDTO>> Handle(GetAllIndustriesQuery request, CancellationToken cancellationToken)
        {
            var industries = await _context.industries.Where(x => x.IsActive).ToListAsync();
            if (industries == null) throw new Exception("industries not found");
            var Mappingindustries = _mapper.Map<List<IndustryDTO>>(industries);
            if (Mappingindustries == null) throw new Exception("Error in Mapping of industries");
            return Mappingindustries;
        }
    }
}
