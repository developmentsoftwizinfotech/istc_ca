using AutoMapper;
using ISTCOSA.Application.Common.Mapping;
using ISTCOSA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class UserSearchDTO:IMapping<Domain.Entities.UserProfile>
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
