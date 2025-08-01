using System.Application.Interface.Services;
using System.Application.MappingProfiles;
using System.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace System.Application
{
    public static class Startup
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InvoiceProfile).Assembly);
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ICashierService, CashierService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICitiesService, CitiesService>();
            return services;
        }
    }
}
