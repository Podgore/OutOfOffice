using OutOfOffice.Common.DTOs.Employee;
using OutOfOffice.Entity.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Common.DTOs.Project
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool Active { get; set; }
        public EmployeeDTO ProjectManager { get; set; } = new EmployeeDTO();
    }
}
