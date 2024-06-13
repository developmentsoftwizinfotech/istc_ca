using ISTCOSA.Application.Common.Mapping;
using ISTCOSA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class UserRegisterDTOs:IMapping<Domain.Entities.UserRegister>
    {
        
        public int BatchId { get; set; }
        public int BatchNumber { get; set; }
        public int RollNumberId { get; set; }
        public int RollNumbers {  get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? CountryName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Images { get; set; }
        public string PinCode { get; set; }
        //public RollNumberDTO RollNumber { get; set; }
        //public BatchDTO Batch { get; set; }
        //public CityDTO City { get; set; }
        //public bool? IsActive { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }

        
    }
}
