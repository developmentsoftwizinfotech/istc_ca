using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.UserProfile.Queries.GetUserProfiles;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.UserProfileHandler
{

    public class GetUserRegisterQueryHandler : IRequestHandler<GetAllUserRegister, List<UserRegisterDTOs>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserRegisterQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserRegisterDTOs>> Handle(GetAllUserRegister request, CancellationToken cancellationToken)
        {
            var userProfiles = await _context.userProfiles.Include(u => u.RollNumber).Include(u => u.RollNumber.Batch)
                .Include(u => u.city).Include(u => u.city.State).Include(u => u.city.State.Country).ToListAsync(cancellationToken);
            var MappedUserProfiles = _mapper.Map<List<UserRegisterDTOs>>(userProfiles);
            return MappedUserProfiles;

        }
    }
}
