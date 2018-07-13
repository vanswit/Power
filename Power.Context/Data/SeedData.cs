using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Power.BO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Context.Data
{
    public class SeedData
    {
        private const string _adminRoleName = "administrator";
        private string _adminEmail = "admin@Power.com";
        private string _adminPassword = "P0wer!power";

        private string[] _defaultRoles = new string[] { _adminRoleName, "customer" };

        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public static async Task Run(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var instance = serviceScope.ServiceProvider.GetService<SeedData>();
                await instance.Initialize();
            }
        }

        public SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Initialize()
        {
            await EnsureRoles();
            await EnsureDefaultUser();
        }

        protected async Task EnsureRoles()
        {
            foreach (var role in _defaultRoles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }

        protected async Task EnsureDefaultUser()
        {
            var adminUsers = await _userManager.GetUsersInRoleAsync(_adminRoleName);

            if (!adminUsers.Any())
            {
                var adminUser = new AppUser()
                {
                    Id = Guid.NewGuid(),
                    Email = _adminEmail,
                    UserName = _adminEmail,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await _userManager.CreateAsync(adminUser, _adminPassword);
                await _userManager.AddToRoleAsync(adminUser, _adminRoleName);
            }
        }
    }
}
