using CatalogAPI.Domain.Interfaces.Authentication;
using Microsoft.AspNetCore.Identity;

namespace CatalogAPI.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if(_userManager.FindByEmailAsync("admin@admin.com.br").Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin@admin.com.br",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@ADMIN.COM.BR",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                IdentityResult result = _userManager.CreateAsync(user, "pass#2023").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        public void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new()
                {
                    Name = "User",
                    NormalizedName = "USER",
                };

                _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                };

                _roleManager.CreateAsync(role);
            }
        }
    }
}
