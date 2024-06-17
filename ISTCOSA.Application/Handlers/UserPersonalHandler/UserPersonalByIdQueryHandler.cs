using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserPersonal.Queries;
using ISTCOSA.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserPersonalHandler
{
    public class UserPersonalByIdQueryHandler : IRequestHandler<UserPersonalByIdQuery, UserPersonalDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;

        public UserPersonalByIdQueryHandler(IApplicationDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }
        public async Task<UserPersonalDTO> Handle(UserPersonalByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var existingDetail = await _context.UserPersonalInformation
                    .Include(x => x.User)
                    .ThenInclude(u => u.RollNumber)
                    .ThenInclude(r => r.Batch)
                    .Include(x => x.User.city)
            .ThenInclude(c => c.State)
            .ThenInclude(s => s.Country)
            .Include(x => x.UserWork)
            .Include(x => x.UserStudent)
            .Include(x => x.UserWork.Company)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (existingDetail != null)
                {
                    var mappeddetail = _mapper.Map<UserPersonalDTO>(existingDetail);

                    var requestUrl = _httpContextAccessor.HttpContext.Request;
                    var baseUrl = $"{requestUrl.Scheme}://{requestUrl.Host}";

                    
                    if (mappeddetail != null && !string.IsNullOrEmpty(mappeddetail.Images))
                    {
                        
                        mappeddetail.ImagePath = $"{baseUrl}/Images/{mappeddetail.Images}";
                    }

                    return mappeddetail;
                }
                throw new Exception($"User personal information not found for the ID: {request.Id}");

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
