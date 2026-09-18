using Microsoft.AspNetCore.Identity;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace MVC.Data
{
    public static class SeedData
    {
        public static async Task<IApplicationBuilder> InitializeData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var adminRole = "Admin";
                var adminUsername = "admin@demo.com";
                var adminPass = "123456789Aa!";
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var adminExists = await roleManager.RoleExistsAsync(adminRole);
                if (!adminExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var adminUser = await userManager.FindByNameAsync(adminUsername);
                if (adminUser == null)
                {
                    adminUser = new IdentityUser { UserName = adminUsername, Email = adminUsername, EmailConfirmed = true };
                    var result = await userManager.CreateAsync(adminUser, adminPass);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(adminUser, adminRole);
                    }
                }

                return app;
            }
        }
    }
}
