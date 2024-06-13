using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Queries.GetUserRegister;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserProfileHandler
{

    public class GetUserRegisterQueryHandler : IRequestHandler<GetAllUserRegister, List<UserRegisterDTOs>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public GetUserRegisterQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserRegisterDTOs>> Handle(GetAllUserRegister request, CancellationToken cancellationToken)
        {
            var userProfiles = await _context. userRegisters.Include(u => u.RollNumber).Include(u => u.RollNumber.Batch)
                .Include(u => u.city).Include(u => u.city.State).Include(u => u.city.State.Country).ToListAsync(cancellationToken);
            var MappedUserProfiles = _mapper.Map<List<UserRegisterDTOs>>(userProfiles);
            return MappedUserProfiles;

        }
    }
}
