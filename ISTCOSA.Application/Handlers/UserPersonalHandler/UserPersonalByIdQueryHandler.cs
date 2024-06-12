using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserPersonal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserPersonalHandler
{
    public class UserPersonalByIdQueryHandler : IRequestHandler<UserPersonalByIdQuery, UserPersonalDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public UserPersonalByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
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
