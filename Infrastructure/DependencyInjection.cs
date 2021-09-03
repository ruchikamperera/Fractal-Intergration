using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
          
            services.AddDbContext<FractolDbContext>(options =>
                options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString") ?? throw new InvalidOperationException(),
                    b => b.MigrationsAssembly(typeof(FractolDbContext).Assembly.FullName)));

            services.AddScoped<IFractolDbContext>(provider => provider.GetService<FractolDbContext>());

            // services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
