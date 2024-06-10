using AutoMapper;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.UserPersonal.Commands;
using ISTCOSA.Domain.Entities;
using ISTCOSA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISTCOSA.Infrastructure.Handlers.UserPersonalHandler
{
    public class CreateUserPersonalCommandHandler : IRequestHandler<CreateUserPersonalCommand, UserPersonalDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserPersonalCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserPersonalDTO> Handle(CreateUserPersonalCommand request, CancellationToken cancellationToken)
        {
            var UserPersonal = new UserPersonalInformation()
            {
                UserId = request.UserId,
                Address = request.Address,
                MaritalStatus= request.MaritalStatus,
                FatherName= request.FatherName,
                SpouseName= request.SpouseName,
                AnniversaryDate= request.AnniversaryDate,
                ISTCNickName= request.ISTCNickName,
                ISTCFriend = request.ISTCFriend,
                ISTCAbout = request.ISTCAbout,
                Comments = request.Comments,
                AboutYourself= request.AboutYourself,
                WhatsappNumber = request.WhatsappNumber,
                MembershipType = request.MembershipType,
                CreatedDate = DateTime.Now,
                IsActive = true,

            };

            await _context.AddAsync(UserPersonal);
            var result = _mapper.Map<UserPersonalDTO>(UserPersonal);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
