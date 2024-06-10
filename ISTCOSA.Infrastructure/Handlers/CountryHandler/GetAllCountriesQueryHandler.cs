using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.Country.Queries;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.CountryHandler
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueries,List<CountryDTO>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllCountriesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CountryDTO>> Handle(GetAllCountriesQueries request, CancellationToken cancellationToken)
        {
            var Countries = await _context.countries.ToListAsync();
            if (request == null) throw new Exception("Countries not found");
            var mappedcountries = _mapper.Map<List<CountryDTO>>(Countries);
            if (mappedcountries == null) throw new Exception("Error in mapping");
            return mappedcountries;
        }
    }
}
