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
        private readonly IEmployeeSevice _employeeService;
        public EmployeeController(IEmployeeSevice employeeService) 
        {
            _employeeService = employeeService;
        }

    }
}
