using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserSearch;
using ISTCOSA.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserSearchHandler
{
    public class UserSearchCommandHandler : IRequestHandler<UserSearchCommand, List<UserRegisterDTOs>>
    {
        private readonly IApplicationDBContext _Context;
        private readonly IMapper _mapper;
        public UserSearchCommandHandler(IApplicationDBContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }
        public async Task<List<UserRegisterDTOs>> Handle(UserSearchCommand request, CancellationToken cancellationToken)
        {
            IQueryable<UserProfile> query = _Context.userProfiles;

            if (!string.IsNullOrEmpty(request.FullName))
            {
                query = query.Where(x => x.FullName.Contains(request.FullName));
            }
            if (!string.IsNullOrEmpty(request.PinCode))
            {
                query = query.Where(x => x.PinCode == request.PinCode);
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email == request.Email);
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber == request.PhoneNumber);
            }
            if (request.BatchNumber != null && request.BatchNumber > 0)
            {
                query = query.Where(x => x.RollNumber.Batch.BatchNumber == request.BatchNumber);
            }
            if (request.RollNumbers != null && request.RollNumbers > 0)
            {
                query = query.Where(x => x.RollNumber.RollNumbers == request.RollNumbers);
            }
            if (request.CountryId != null && request.CountryId > 0)
            {
                query = query.Where(x => x.city.State.CountryId == request.CountryId);
            }

            int totalRecords = await query.CountAsync(cancellationToken);
            query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

            var studentList = await query.ToListAsync(cancellationToken);
            var mappedData = _mapper.Map<List<UserRegisterDTOs>>(studentList);

            return mappedData;

        }
    }
}
