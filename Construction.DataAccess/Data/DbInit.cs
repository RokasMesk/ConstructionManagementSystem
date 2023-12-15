using Construction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.DataAccess.Data
{
    public class DbInit: IDbInit
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbInit(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager=userManager;
            _roleManager=roleManager;
            _db=db;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                
            }

            if (!_roleManager.RoleExistsAsync("Employee").GetAwaiter().GetResult())
            {
                // Creating roles if they don't exist
                _roleManager.CreateAsync(new IdentityRole("Employee")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();

                // Creating an admin user if it doesn't exist
                if (_userManager.FindByEmailAsync("admin@gmail.com").GetAwaiter().GetResult() == null)
                {
                    var adminWorker = new Worker
                    {
                        Name = "Rokas",
                        LastName = "Mesk",
                        Title = "Admin",
                        PhoneNumber = "+370606060"
                    };

                    _db.Workers.Add(adminWorker);
                    _db.SaveChanges();

                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin@gmail.com",
                        WorkerId = adminWorker.WorkerId, // Assign the WorkerId to the newly created Worker's Id
                        Email = "admin@gmail.com"
                    };

                    var result = _userManager.CreateAsync(adminUser, "Admin123#").GetAwaiter().GetResult();

                    if (result.Succeeded)
                    {
                        // Adding the "Admin" role to the admin user
                        var user = _userManager.FindByEmailAsync("admin@gmail.com").GetAwaiter().GetResult();
                        _userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
                    }
                    return;
                }
            }
        }

    }
}

