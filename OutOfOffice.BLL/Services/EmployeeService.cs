using OutOfOffice.BLL.Services.Interfaces;
using OutOfOffice.Common.DTOs.Employee;

namespace OutOfOffice.BLL.Services
{
    public class EmployeeService : IEmployeeSevice
    {
        public Task<List<EmployeeDTO>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> GetEmployeeAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
