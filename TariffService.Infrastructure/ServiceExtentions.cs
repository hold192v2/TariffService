using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TariffService.Domain.Entities;
using TariffService.Domain.Interfaces;
using TariffService.Infrastructure.Context;
using TariffService.Infrastructure.Repositories;

namespace TariffService.Infrastructure
{
    public static class ServiceExtentions
    {
        public static void ConfigurePresistanceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("postgres");
            IServiceCollection serviceCollection = services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString, x => x.MigrationsAssembly("Project.Infrastructure")), ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDynamicTariff, DynamicTariffRepository>();
            services.AddScoped<IStaticTariffInterface, StaticTariffRepository>();
            services.AddScoped<ITariffCart, TariffCartRepository>();
            services.AddScoped<IUnitPrice, UnitPriceRepository>();

        }
    }
}
