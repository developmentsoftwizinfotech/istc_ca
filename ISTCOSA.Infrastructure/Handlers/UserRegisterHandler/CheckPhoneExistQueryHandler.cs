using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.UserRegister.Queries.GetUserRegister;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.UserRegisterHandler
{
    public class CheckPhoneExistQueryHandler : IRequestHandler<CheckPhoneNumberExistQuery, UserRegisterDTOs>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CheckPhoneExistQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserRegisterDTOs> Handle(CheckPhoneNumberExistQuery request, CancellationToken cancellationToken)
        {
            var phoneExist = await _context.userProfiles.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
            if (phoneExist != null)
            {
                var mappeddata = _mapper.Map<UserRegisterDTOs>(phoneExist);
                return mappeddata;
            }
            else
            {
                return null;
            }
        }
    }
}
