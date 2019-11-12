using Microsoft.AspNetCore.Identity;
using Miniature_Gallery_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miniature_Gallery_API
{
    public class DBInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DBInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            AddAdminUser();
        }

        private AppUser CreateUser(string email, string firstName, string lastName)
        {
            if (_userManager.FindByNameAsync(email).Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName
                };
                // add user
                var result = _userManager.CreateAsync(user, "Testing123!").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }

        private void AddAdminUser()
        {
            // create an Admin role, if it doesn't already exist
            if (_roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = _roleManager.CreateAsync(adminRole).Result;
            }

            var user = CreateUser("admin@test.com", "admin", "admin");
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
            //// create an Admin user, if it doesn't already exist
            if (_userManager.FindByNameAsync("admin").Result == null)
            {
                AppUser userAdmin = new AppUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };

                // add the Admin user to the Admin role
                IdentityResult result = _userManager.CreateAsync(userAdmin, "AdminPassword123!").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(userAdmin, "Admin").Wait();
                }
            }
        }
    }
}
