using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.BLL.Services.Interfaces;
using OutOfOffice.Common.DTOs.Project;
using OutOfOffice.DAL.Repositories.Interfaces;
using OutOfOffice.Entity;

namespace OutOfOffice.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;

        public ProjectService(IRepository<Project> projectRepository, IMapper mapper, UserManager<Employee> userManager)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ProjectDTO> AddProjectAsync(RequestProjectDTO dto, Guid projectManagerId)
        {
            var PM = await _userManager.FindByIdAsync(projectManagerId.ToString())
                ?? throw new Exception("Unable to find user with current Id");

            if(dto.StartDate > dto.EndDate)
                throw new Exception("Date issue: end date must be greater than start");

            var entity = _mapper.Map<Project>(dto);

            entity.ProjectManager = PM;

            await _projectRepository.InsertAsync(entity);

            return _mapper.Map<ProjectDTO>(entity);
        }

        public async Task<bool> DeleteProjectAsync(Guid projectId)
        {
            var entity = await _projectRepository.FirstOrDefaultAsync(p => p.Id == projectId)
                ?? throw new Exception($"Unable to find entity with such key: {projectId}");

            return await _projectRepository.DeleteAsync(entity);
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(Guid projectId)
        {
            var entity = await _projectRepository.Include(p => p.ProjectManager).FirstOrDefaultAsync(p => p.Id == projectId)
                ?? throw new Exception($"Unable to find entity with such key: {projectId}");

            return _mapper.Map<ProjectDTO>(entity);
        }

        public async Task<List<ProjectDTO>> GetProjectsAsync()
        {
            var projects = await _projectRepository.ToListAsync();

            return _mapper.Map<List<ProjectDTO>>(projects);
        }

        public async Task<ProjectDTO> UpdateProjectAsync(RequestProjectDTO dto, Guid projectId, Guid projectManagerId)
        {
            var PM = await _userManager.FindByIdAsync(projectManagerId.ToString())
                ?? throw new Exception("Unable to find user with current Id");

            var entity = await _projectRepository.Include(p => p.ProjectManager).FirstOrDefaultAsync(p => p.Id == projectId)
               ?? throw new Exception($"Unable to find entity with such key: {projectId}");

            if (dto.StartDate > dto.EndDate)
                throw new Exception("Date issue: end date must be greater than start");

            entity.ProjectManager = PM;

            _mapper.Map(dto, entity);

            await _projectRepository.UpdateAsync(entity);

            return _mapper.Map<ProjectDTO>(entity);
        }
    }
}
