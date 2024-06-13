using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserPersonal.Commands
{
    public class CreateUserPersonalCommand : IRequest<UserPersonalDTO>
    {
        public string UserId { get; set; }
        public int ProfessionId { get; set; }
        public string? Address { get; set; }
        public string? MaritalStatus { get; set; }
        public string? FatherName { get; set; }
        public string? SpouseName { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public string? ISTCNickName { get; set; }
        public string? ISTCFriend { get; set; }
        public string? ISTCAbout { get; set; }
        public string? Comments { get; set; }
        public string? AboutYourself { get; set; }
        public string? WhatsappNumber { get; set; }
        public string? MembershipType { get; set; }
        public string? Designation { get; set; }
        public string? ContactNumber { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? EmailID { get; set; }
        public string? WorkProfile { get; set; }
        public string? CollegeName { get; set; }
        public string? Degree { get; set; }
        public string? Skills { get; set; }
        public DateTime? JoiningYear { get; set; }
        public DateTime? ExpectedComplitionYear { get; set; }
        public string CompanyName { get; set; }
        public int CityId { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyPhoneNumber { get; set; }
        public string? CompanyEmailAddress { get; set; }
    }
}
