using Weelo.Core.Interfaces;
using Weelo.Core.Services;

using Microsoft.Extensions.DependencyInjection;
namespace Weelo.Core.Registers
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            //services.AddTransient();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPropertyService, PropertyService>();

        }
    }
}
