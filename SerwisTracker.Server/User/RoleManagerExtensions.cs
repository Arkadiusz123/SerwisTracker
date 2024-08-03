﻿using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace SerwisTracker.Server.User
{
    public static class RoleManagerExtensions
    {
        public async static Task<bool> UpdateRoles(this RoleManager<IdentityRole> roleManager)
        {
            Type t = typeof(UserRoles);
            FieldInfo[] roles = t.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo r in roles)
            {
                var role = r.GetValue(null)!.ToString();

                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
            return true;
        }
    }
}
