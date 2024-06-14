using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserPersonal.Commands;
using ISTCOSA.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserPersonalHandler
{
    public class CreateUserPersonalCommandHandler : IRequestHandler<CreateUserPersonalCommand, UserPersonalDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public CreateUserPersonalCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserPersonalDTO> Handle(CreateUserPersonalCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    
                    var userPersonal = new UserPersonalInformation()
                    {
                        UserId = request.UserId,
                        Address = request.Address,
                        MaritalStatus = request.MaritalStatus,
                        FatherName = request.FatherName,
                        SpouseName = request.SpouseName,
                        AnniversaryDate = request.AnniversaryDate,
                        ISTCNickName = request.ISTCNickName,
                        ISTCFriend = request.ISTCFriend,
                        ISTCAbout = request.ISTCAbout,
                        Comments = request.Comments,
                        AboutYourself = request.AboutYourself,
                        WhatsappNumber = request.WhatsappNumber,
                        MembershipType = request.MembershipType,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };

                    await _context.AddAsync(userPersonal);
                    var profession = await _context.professions.FirstOrDefaultAsync(x => x.Id == request.ProfessionId);
                    if (profession == null) throw new Exception("Profession not Found");

                    if (profession.Name == "Student")
                    {
                        var student = new UserStudent()
                        {
                            Degree = request.Degree,
                            Skills = request.Skills,
                            CollegeName = request.CollegeName,
                            JoiningYear = request.JoiningYear,
                            ExpectedComplitionYear = request.ExpectedComplitionYear,
                            CreatedDate = DateTime.Now,
                            IsActive = true,
                        };

                        await _context.AddAsync(student);
                    }
                    else if (profession.Name == "Private Sector" || profession.Name == "Self Employed" || profession.Name == "Entrepreneur / Own Business")
                    {
                        Company company = null;

                        if (request.CompanyId > 0)
                        {
                            
                            company = await _context.companies.FindAsync(request.CompanyId);
                        }
                        else if (!string.IsNullOrEmpty(request.CompanyName))
                        {
                            company = await _context.companies.FirstOrDefaultAsync(c => c.Name == request.CompanyName, cancellationToken);
                            if (company == null)
                            {
                                company = new Company
                                {
                                    Name = request.CompanyName,
                                    Address = request.CompanyAddress,
                                    EmailAddress = request.CompanyEmailAddress,
                                    PhoneNumber = request.CompanyPhoneNumber,
                                    CityId=request.CityId,
                                    CreatedDate = DateTime.Now,
                                    IsActive = true,
                                   
                                };
                                await _context.AddAsync(company);
                                await _context.SaveChangesAsync(); 
                            }
                        }

                        var userWork = new UserWork()
                        {
                            WorkProfile = request.WorkProfile,
                            Designation = request.Designation,
                            ContactNumber = request.ContactNumber,
                            EmailID = request.EmailID,
                            FromDate= request.FromDate,
                            ToDate= request.ToDate,
                            CompanyId = company.Id, 
                            ProfessionId= request.ProfessionId,
                            CreatedDate = DateTime.Now,
                            IsActive = true,
                        };

                        await _context.AddAsync(userWork);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    var result = _mapper.Map<UserPersonalDTO>(userPersonal);
                    return result;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }




    }
}

