using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.UserPersonal.Queries;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.UserPersonalHandler
{
    public class UserPersonalByIdQueryHandler : IRequestHandler<UserPersonalByIdQuery, UserPersonalDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserPersonalByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserPersonalDTO> Handle(UserPersonalByIdQuery request, CancellationToken cancellationToken)
        {
            var existingDetail = await _context.UserPersonalInformation.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (existingDetail != null)
            {
                var mappeddetail = _mapper.Map<UserPersonalDTO>(existingDetail);
                return mappeddetail;
            }
            return null;
        }
    }
}
