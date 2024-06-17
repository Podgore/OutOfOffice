using OutOfOffice.Entity.Enum;

namespace OutOfOffice.Common.DTOs.Employee
{
    public class EmployeeDTO
    {
        public string FullName { get; set; } = string.Empty;
        public Position Position { get; set; }
        public bool Status { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
