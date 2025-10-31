using GymDataAccsess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Data.SeedData
{
    public static class IDentityDataSeeding
    {
        public static async Task<bool> seeddata(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> user)
        {
            try
            {
                // 1️⃣ Seed Roles
                
                
                    var roles = new List<IdentityRole>()
            {
                new IdentityRole() { Name = "admin" },
                new IdentityRole() { Name = "SuperAdmin" }
            };

                    foreach (var role in roles)
                    {
                        await roleManager.CreateAsync(role);
                    }
                

                // 2️⃣ Seed Users
                if (!user.Users.Any())
                {
                    var SuperAdmin = new ApplicationUser()
                    {
                        FirstName = "Sayed",
                        LastName = "Hesham",
                        UserName = "SayedHesham",
                        Email = "elsayed@gmail.com",
                        PhoneNumber = "01124697796"
                    };

                    var result1 = await user.CreateAsync(SuperAdmin, "p@ssw0rd");
                    if (result1.Succeeded)
                        await user.AddToRoleAsync(SuperAdmin, "SuperAdmin");

                    var Admin = new ApplicationUser()
                    {
                        FirstName = "Ahmed",
                        LastName = "Hesham",
                        UserName = "AhmedHesham",
                        Email = "ahmed@gmail.com",
                        PhoneNumber = "01007849787"
                    };

                    var result2 = await user.CreateAsync(Admin, "p@ssw0rd");
                    if (result2.Succeeded)
                        await user.AddToRoleAsync(Admin, "admin");
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding Failed: {ex}");
                return false;
            }
        }

    }
}
