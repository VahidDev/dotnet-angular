using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.DAL;

namespace Project.Infrastructure.Utilities.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void Seed (this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
        }
    }
}
