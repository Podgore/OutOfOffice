using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutOfOffice.BLL.Services.Interfaces;

namespace OutOfOffice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "HR Manager")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _employeeService.GetAllEmployeesAsync();
            return Ok(users);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "HR Manager")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(user);
        }
    }
}
