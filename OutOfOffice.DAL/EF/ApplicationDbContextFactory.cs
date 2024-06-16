using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OutOfOffice.DAL.EF;

namespace StudyHub.DAL.EF;

class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Server=(local);Database=OutOfOffice;Trusted_Connection=True;TrustServerCertificate=true;";
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}