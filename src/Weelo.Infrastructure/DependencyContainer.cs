using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weelo.Core.Interfaces;
using Weelo.Infrastructure.Data;

namespace Weelo.Infrastructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<WeeloContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            services.AddDbContext<WeeloContext>(options => options.UseSqlServer(configuration.GetConnectionString("LocalConnection")), ServiceLifetime.Singleton);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

