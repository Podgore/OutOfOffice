using OutOfOffice.Common.DTOs.Employee;

namespace OutOfOffice.BLL.Services.Interfaces
{
    public interface IEmployeeSevice
    {
        public Task<EmployeeDTO> GetEmployeeAsync(Guid userId);
        public Task<List<EmployeeDTO>> GetAllEmployees();

    }
}
