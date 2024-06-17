using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OutOfOffice.BLL.Services.Interfaces;
using OutOfOffice.Common.DTOs.Employee;
using OutOfOffice.DAL.Repositories.Interfaces;
using OutOfOffice.Entity;
using System.Data.Entity;

namespace OutOfOffice.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IRepository<Employee> _userRepository;
        private readonly IMapper _mapper;

        public EmployeeService(UserManager<Employee> userManager, IRepository<Employee> userRepository, IMapper mapper) 
        { 
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var users = _userRepository.ToList();

            return _mapper.Map<List<EmployeeDTO>>(users);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(Guid userId)
        {
            var user = await _userRepository.FirstOrDefaultAsync(u => u.Id == userId)
                ?? throw new Exception("User with current id doesn`t exist");

            return _mapper.Map<EmployeeDTO>(user);
        }
    }
}
