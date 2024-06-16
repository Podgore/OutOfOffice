using OutOfOffice.Entity.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Entity
{
    public class LeaveRequest : EntityBase
    {
        public AbsenceReason AbsenceReason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Status Status { get; set; }
        
        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
