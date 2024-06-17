using OutOfOffice.Common.DTOs.Employee;

namespace OutOfOffice.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeDTO> GetEmployeeByIdAsync(Guid userId);
        public Task<List<EmployeeDTO>> GetAllEmployeesAsync();

    }
}
