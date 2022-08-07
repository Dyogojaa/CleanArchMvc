using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public void SeedRoles()
        {

            if (!_roleManager.RoleExistsAsync("User").Result)
            {

                IdentityRole role = new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                };

                IdentityResult result = _roleManager.CreateAsync(role).Result;

            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {

                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                IdentityResult result = _roleManager.CreateAsync(role).Result;

            }

        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("dyogo@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = "dyogo@localhost";
                user.UserName = "dyogo@localhost";
                user.NormalizedUserName = "DYOGO@LOCALHOST";
                user.NormalizedEmail = "DYOGO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#@2022").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }


            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = "admin@localhost";
                user.UserName = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#@2022").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }
    }
}
