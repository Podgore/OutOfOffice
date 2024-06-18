using OutOfOffice.Entity.Enum;

namespace OutOfOffice.Common.DTOs.Project
{
    public class RequestProjectDTO
    {
        public ProjectType ProjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
