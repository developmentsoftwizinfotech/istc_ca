using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.UserEmployment.Commands;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Handlers.UserEmploymentHandler
{
    public class DeleteUserProfessionalCommandHandler : IRequestHandler<DeletePostEmploymentCommand, PostEmploymentDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeleteUserProfessionalCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostEmploymentDTO> Handle(DeletePostEmploymentCommand request, CancellationToken cancellationToken)
        {
            var existingUserEmployment = await _context.postEmployments.FindAsync(request.Id);
            if (existingUserEmployment != null)
            {
                existingUserEmployment.IsActive = false;
                existingUserEmployment.DeletedDate = DateTime.Now;
            }
            var mappeddata = _mapper.Map<PostEmploymentDTO>(existingUserEmployment);
            await _context.SaveChangesAsync();
            return mappeddata;
        }
    }
}
