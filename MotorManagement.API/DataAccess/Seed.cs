using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataAccess
{
    public class Seed
    {
        public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string roleData = File.ReadAllText(dir + @"\RoleSeedData.json");

                List<Role> roles = JsonConvert.DeserializeObject<List<Role>>(roleData);
                foreach (Role role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }

                //create product department users
                User productAdmin = CreateKSBUser("product", "admin");
                AddToRole(userManager, roleManager, productAdmin, "ProductAdmin");

                User productOperator = CreateKSBUser("product", "operator");
                AddToRole(userManager, roleManager, productOperator, "ProductOperator");

                //create purchasing department users
                User purchasingAdmin = CreateKSBUser("purchasing", "admin");
                AddToRole(userManager, roleManager, purchasingAdmin, "PurchasingAdmin");

                User purchasingOperator = CreateKSBUser("purchasing", "operator");
                AddToRole(userManager, roleManager, purchasingOperator, "PurchasingOperator");

                //create mdm department users
                User mdmAdmin = CreateKSBUser("mdm", "admin");
                AddToRole(userManager, roleManager, mdmAdmin, "MDMAdmin");

                User mdmOperator = CreateKSBUser("mdm", "operator");
                AddToRole(userManager, roleManager, mdmOperator, "MDMOperator");

                //create vendor users
                User skynet = CreateVendorUser("skynet");
                AddToRole(userManager, roleManager, skynet, "Vendor");

                User motorProvider_1 = CreateVendorUser("provider1");
                AddToRole(userManager, roleManager, motorProvider_1, "Vendor");

                User motorProvider_2 = CreateVendorUser("provider2");
                AddToRole(userManager, roleManager, motorProvider_2, "Vendor");

                User motorProvider_3 = CreateVendorUser("provider3");
                AddToRole(userManager, roleManager, motorProvider_3, "Vendor");
            }
        }

        private static User CreateKSBUser(string departament, string role)
        {
            User user = new User
            {
                UserName = $"{departament}_{role}".ToLower(),
                Email = $"{departament}_{role}@{departament}.com",
                EmailConfirmed = true
            };
            return user;
        }

        private static User CreateVendorUser(string vendor)
        {
            User user = new User
            {
                UserName = $"{vendor}".ToLower(),
                Email = $"{vendor}@{vendor}.com",
                EmailConfirmed = true
            };
            return user;
        }

        private static void AddToRole(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            User user,
            string roleName)
        {
            userManager.CreateAsync(user, "Password_123").Wait();
            var createdUser = userManager.FindByNameAsync(user.UserName).Result;
            var role = roleManager.FindByNameAsync(roleName).Result;
            userManager.AddToRoleAsync(createdUser, role.Name).Wait();
        }
    }
}
