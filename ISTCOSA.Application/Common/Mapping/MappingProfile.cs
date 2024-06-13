using AutoMapper;
 
namespace ISTCOSA.Application.Common.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyDTO,Domain.Entities.Company>().ReverseMap();
            CreateMap<ProfessionDTO,Domain.Entities.Profession>().ReverseMap();
            CreateMap<IndustryDTO, Domain.Entities.Industry>().ReverseMap();
            CreateMap<ProfessionDTO, Domain.Entities.Profession>().ReverseMap();

            CreateMap<UserRegisterDTOs, Domain.Entities.UserRegister>();
            CreateMap<Domain.Entities.UserRegister, UserRegisterDTOs>()
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.BatchId, opt => opt.MapFrom(src => src.RollNumber.Batch.BatchId))
                .ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.RollNumber.Batch.BatchNumber))
                .ForMember(dest => dest.RollNumberId, opt => opt.MapFrom(src => src.RollNumberId))
                .ForMember(dest => dest.RollNumbers, opt => opt.MapFrom(src => src.RollNumber.RollNumbers))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.city.Name))
                .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.city.StateId))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.city.State.Name))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.city.State.CountryId))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.city.State.Country.Name));
            CreateMap<UserPersonalDTO, UserPersonalInformation>();
            CreateMap<UserPersonalInformation, UserPersonalDTO>()
           .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.User.LastLoginDate))
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<PostEmploymentDTO,PostEmployment>();
            CreateMap<PostEmployment, PostEmploymentDTO>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.CompanyAddress, opt => opt.MapFrom(src => src.Company.Address))
                .ForMember(dest => dest.CompanyPhoneNumber, opt => opt.MapFrom(src => src.Company.PhoneNumber))
                .ForMember(dest => dest.CompanyEmailAddress, opt => opt.MapFrom(src => src.Company.EmailAddress))
                .ForMember(dest => dest.IndustryId, opt => opt.MapFrom(src => src.Industry.Id))
                .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.Industry.Name))
                .ForMember(dest => dest.EmploymentTypeId, opt => opt.MapFrom(src => src.EmploymentType.Id))
                .ForMember(dest => dest.EmploymentTypeName, opt => opt.MapFrom(src => src.EmploymentType.Name));

            CreateMap<RollNumberDTO, RollNumber>();
            CreateMap<RollNumber, RollNumberDTO>()
                .ForMember(dest => dest.BatchId, opt => opt.MapFrom(src => src.Batch.BatchId))
                .ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.Batch.BatchNumber));

            CreateMap<BatchDTO, Domain.Entities.Batch>().ReverseMap();
            CreateMap<CountryDTO, Domain.Entities.Country>().ReverseMap();
            CreateMap<StateDTO, Domain.Entities.State>();
            CreateMap<Domain.Entities.State, StateDTO>()
                 .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CityDTO, Domain.Entities.City>().ReverseMap();

        }

    }
}
