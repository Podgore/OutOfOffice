using Microsoft.AspNetCore.Mvc;
using OutOfOffice.BLL.Services.Interfaces;
using OutOfOffice.Common.Extensions;
using OutOfOffice.Common.DTOs.Project;
using Microsoft.AspNetCore.Authorization;

namespace OutOfOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProjectsAsync()
        {
            var result = await _projectService.GetProjectsAsync();
            return Ok(result);      
        }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProjectByIdAsync(Guid projectId)
        {
            var result = await _projectService.GetProjectByIdAsync(projectId);
            return Ok(result);      
        }

        [HttpPost]
        public async Task<IActionResult> InsertProject(RequestProjectDTO dto)
        {
            var userId = HttpContext.GetUserId();
            var result = await _projectService.AddProjectAsync(dto, userId);
            return Ok(result);
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(RequestProjectDTO dto, Guid projectId)
        {
            var userId = HttpContext.GetUserId();
            var result = await _projectService.UpdateProjectAsync(dto, projectId, userId);
            return Ok(result);
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(Guid projectId)
        {
            var userId = HttpContext.GetUserId();
            var result = await _projectService.DeleteProjectAsync(projectId);
            return Ok(result);
        }
    }
}
