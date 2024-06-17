using OutOfOffice.Entity.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Entity
{
    public class ApprovalRequest : EntityBase
    {
        public string Comment { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.New;

        [ForeignKey(nameof(Approver))]
        public Guid EmployeeId { get; set; }

        [ForeignKey(nameof(LeaveRequest))]
        public Guid LeaveRequestId { get; set; }

        public Employee Approver { get; set; } = null!;
        public LeaveRequest LeaveRequest { get; set; } = null!;
    }
}
