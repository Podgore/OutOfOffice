using Microsoft.AspNetCore.Identity;
using OutOfOffice.Entity.Enum;

namespace OutOfOffice.Entity
{
    public class Employee : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public Subdivision Subdivision { get; set; }
        public Position Position { get; set; }
        public bool Status { get; set; }
        public int OutOfOfficeBalance { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
