using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.UserSearch
{
    public class UserSearchCommand:IRequest<List<UserRegisterDTOs>>
    {
        public int? BatchNumber { get; set; }
        public int? RollNumbers { get; set; }
        public int? CountryId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PinCode { get; set; }
    }
}
