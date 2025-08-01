using System.Application.Interface.Repositories;
using System.Infrastructure.Data;
using System.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace System.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SystemDBContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("LocalConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
