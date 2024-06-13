 

namespace ISTCOSA.Application.Common.DTOs
{
    public class UserPersonalDTO:IMapping<UserPersonalInformation>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public string AnniversaryDate { get; set; }
        public string ISTCNickName { get; set; }
        public string ISTCFriend { get; set; }
        public string ISTCAbout { get; set; }
        public string Comments { get; set; }
        public string AboutYourself { get; set; }
        public string WhatsappNumber { get; set; }
        public string MembershipType { get; set; }
        public string LastLoginDate { get; set; }
    }
}
