using AutoMapper;
using OutOfOffice.Common.DTOs.Project;
using OutOfOffice.Entity;

namespace OutOfOffice.BLL.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();

            CreateMap<RequestProjectDTO, Project>();
        }
    }
}
