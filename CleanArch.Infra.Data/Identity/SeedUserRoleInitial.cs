using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Identity
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

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("admin@admin").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@admin",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@ADMIN",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = _userManager.CreateAsync(user, "J@n3ir0").Result;

                if (result.Succeeded) _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        public void SeedRoles()
        {
            var roles = new List<IdentityRole>()
                {
                    new IdentityRole { Name = "User", NormalizedName = "USER" },
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
                };


            foreach (var role in roles)
            {
                if (!_roleManager.RoleExistsAsync(role.Name).Result)
                {
                   var result = _roleManager.CreateAsync(role).Result;
                }

            }
        }
    }
}
