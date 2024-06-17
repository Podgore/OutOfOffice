using AutoMapper;
using OutOfOffice.Common.DTOs.Auth;
using OutOfOffice.Common.DTOs.Employee;
using OutOfOffice.Entity;

namespace OutOfOffice.BLL.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<RegisterUserDTO, Employee>()
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
