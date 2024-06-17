using OutOfOffice.Common.DTOs.Employee;

namespace OutOfOffice.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeDTO> GetEmployeeByEmailAsync(string userEmail);
        public Task<List<EmployeeDTO>> GetAllEmployeesAsync();

    }
}
