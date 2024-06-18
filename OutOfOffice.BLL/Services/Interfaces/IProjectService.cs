using OutOfOffice.Common.DTOs.Project;

namespace OutOfOffice.BLL.Services.Interfaces
{
    public interface IProjectService
    {
        public Task<ProjectDTO> AddProjectAsync(RequestProjectDTO dto, Guid projectManagerId);

        public Task<bool> DeleteProjectAsync(Guid projectId);

        public Task<ProjectDTO> GetProjectByIdAsync(Guid projectId);

        public Task<List<ProjectDTO>> GetProjectsAsync();

        public Task<ProjectDTO> UpdateProjectAsync(RequestProjectDTO dto, Guid projectId, Guid projectManagerId);
    }
}
