using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.UserPersonal.Commands
{
    public class CreateUserPersonalCommand:IRequest<UserPersonalDTO>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public string ISTCNickName { get; set; }
        public string ISTCFriend { get; set; }
        public string ISTCAbout { get; set; }
        public string Comments { get; set; }
        public string AboutYourself { get; set; }
        public string WhatsappNumber { get; set; }
        public string MembershipType { get; set; }
    }
}
