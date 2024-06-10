using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.UserSearch;
using ISTCOSA.Domain.Entities;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.UserSearchHandler
{
    public class UserSearchCommandHandler : IRequestHandler<UserSearchCommand, List<UserRegisterDTOs>>
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _mapper;
        public UserSearchCommandHandler(ApplicationDbContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }
        public async Task<List<UserRegisterDTOs>> Handle(UserSearchCommand request, CancellationToken cancellationToken)
        {
            IQueryable<UserProfile> query = _Context.userProfiles;

            if (!string.IsNullOrEmpty(request.FullName))
            {
                query = query.Where(x => x.FullName == request.FullName);
            }
            else if (!string.IsNullOrEmpty(request.PinCode))
            {
                query = query.Where(x => x.PinCode == request.PinCode);
            }
            else if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email == request.Email);
            }

            else if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber == request.PhoneNumber);
            }
            else if (request.BatchNumber != null && request.BatchNumber > 0)
            {
                query = query.Where(x => x.RollNumber.Batch.BatchNumber == request.BatchNumber);
            }
            else if (request.RollNumbers != null && request.RollNumbers > 0)
            {
                query = query.Where(x => x.RollNumber.RollNumbers == request.RollNumbers);
            }
            else if (request.CountryId != null && request.CountryId > 0)
            {
                query = query.Where(x => x.city.State.CountryId == request.CountryId);
            }
            var studentList = await query.ToListAsync(cancellationToken);
            var mappedData = _mapper.Map<List<UserRegisterDTOs>>(studentList);
            return mappedData;

        }
    }
}
