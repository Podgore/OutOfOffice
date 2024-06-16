using OutOfOffice.Entity.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Entity
{
    public class Project : EntityBase
    {
        public ProjectType ProjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool Active { get; set; }

        [ForeignKey(nameof(ProjectManager))]
        public Guid EmployeeId { get; set; }

        public Employee ProjectManager { get; set; } = null!;
    }
}
