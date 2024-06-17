using Microsoft.AspNetCore.Identity;
using OutOfOffice.Seeding.Interface;

namespace OutOfOffice.Seeding.Behaviours
{
    public class RoleSeedingBehaviour : ISeedingBehaviour
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public RoleSeedingBehaviour(RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            var roles = new List<string>
        {
            "Employee",
            "HR Manager",
            "Project Manager",
            "Administrator"
        };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }
    }
}
