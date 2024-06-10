using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.EmploymentType.Queries;
using ISTCOSA.Application.Industry.Queries;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.EmploymentTypeHandler
{
    public class GetAllProfessionQueryHandler : IRequestHandler<GetAllProfessionListQuery, List<ProfessionDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllProfessionQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProfessionDTO>> Handle(GetAllProfessionListQuery request, CancellationToken cancellationToken)
        {
            var EmploymentType = await _context.professions.Where(x => x.IsActive).ToListAsync();
            if (EmploymentType == null) throw new Exception("EmploymentType not found");
            var MappingEmploymentType = _mapper.Map<List<ProfessionDTO>>(EmploymentType);
            if (MappingEmploymentType == null) throw new Exception("Error in Mapping of EmploymentType");
            return MappingEmploymentType;
        }
    }
}
