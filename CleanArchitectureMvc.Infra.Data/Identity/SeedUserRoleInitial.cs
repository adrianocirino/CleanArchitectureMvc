using System;
using CleanArchitectureMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureMvc.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly  RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            var emailUser = "usuario@localhost";
            var emailAdmin = "admin@localhost";
            if (_userManager.FindByEmailAsync(emailUser).Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = emailUser;
                user.Email = emailUser;
                user.NormalizedEmail = emailUser.ToUpper();
                user.NormalizedEmail = emailUser.ToUpper();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var result = _userManager.CreateAsync(user, "Adriano@00").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (_userManager.FindByEmailAsync(emailAdmin).Result == null)
            {
                var user = new ApplicationUser();
                user.UserName = emailAdmin;
                user.Email = emailAdmin;
                user.NormalizedEmail = emailAdmin.ToUpper();
                user.NormalizedEmail = emailAdmin.ToUpper();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var result = _userManager.CreateAsync(user, "Adriano@00").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            var roleUser = "User";
            var roleAdmin = "Admin";

            if (!_roleManager.RoleExistsAsync(roleUser).Result)
            {
                var role = new IdentityRole();
                role.Name = roleUser;
                role.NormalizedName = roleUser.ToUpper();

                _ = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync(roleAdmin).Result)
            {
                var role = new IdentityRole();
                role.Name = roleAdmin;
                role.NormalizedName = roleAdmin.ToUpper();

                _ = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
