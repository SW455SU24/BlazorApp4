using Microsoft.AspNetCore.Identity;

namespace BlazorApp4.Data
{

    public static class ApplicationDbContextSeed
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "User", "Manager" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }

    public static class SeedDataExtension
    {
        public static IApplicationBuilder UseSeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    ApplicationDbContextSeed.SeedRolesAsync(services).Wait();
                }
                catch (Exception ex)
                {
                    // Log errors or handle them as needed
                    throw;
                }
            }

            return app;
        }
    }
}
