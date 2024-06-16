using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.Entity;

namespace OutOfOffice.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<Employee, IdentityRole<Guid>, Guid>
    {
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;
        public DbSet<ApprovalRequest> ApprovalRequest { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
