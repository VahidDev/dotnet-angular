using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.DAL;
using Project.Infrastructure.Mapper;
using Project.Infrastructure.Repositories.Abstraction;
using Project.Infrastructure.Repositories.Implementation;

namespace Project.Infrastructure.Utilities.DependencyResolvers
{
    public static class CoreDependencies
    {
        public static void AddCoreDependencies(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
