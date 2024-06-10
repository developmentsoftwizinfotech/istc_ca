using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.UserRegister.Queries.GetUserRegister;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.UserRegisterHandler
{
    public class CheckEmailExistQueryHandler : IRequestHandler<CheckEmailExistQuery, UserRegisterDTOs>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CheckEmailExistQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public async Task<UserRegisterDTOs> Handle(CheckEmailExistQuery request, CancellationToken cancellationToken)
        {
            var EmailExist = await _context.userProfiles.FirstOrDefaultAsync(x=>x.Email==request.Email);
            if (EmailExist != null)
            {
                var mappeddata = _mapper.Map<UserRegisterDTOs>(EmailExist);
                return mappeddata;
            }
            else
            {
                return null;
            }
        }
    }
}
