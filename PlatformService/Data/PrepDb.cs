using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }

        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("---> Attemting to apply migrations...");
                try
                {
                    context.Database.Migrate();

                }
                catch (Exception ex)
                {

                    Console.WriteLine($"---> Could not run migrations: {ex.Message}");
                }
            }
            if (!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding Data");

                context.Platforms.AddRange(
                    new Platform() { Name = "Xbox", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Docker Inc.", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have data");
            }
        }
    }
}