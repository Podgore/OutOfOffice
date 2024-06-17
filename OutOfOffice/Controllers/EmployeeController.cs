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
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _employeeService.GetAllEmployeesAsync();
            return Ok(users);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserByEmailAsync(string email)
        {
            var user = await _employeeService.GetEmployeeByEmailAsync(email);
            return Ok(user);
        }
    }
}
