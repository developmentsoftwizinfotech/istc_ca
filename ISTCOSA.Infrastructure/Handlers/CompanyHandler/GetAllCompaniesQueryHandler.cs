using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.Company.Queries;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.CompanyHandler
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllCompaniesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CompanyDTO>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _context.companies.Where(x => x.IsActive).ToListAsync();
            if (companies == null) throw new Exception("companies not found");
            var Mappingcompanies = _mapper.Map<List<CompanyDTO>>(companies);
            if (Mappingcompanies == null) throw new Exception("Error in Mapping of Companies");
            return Mappingcompanies;
        }
    }
}
