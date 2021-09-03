
using Application;
using Application.Common.Interfaces;
using FunctionApi;
using Infrastructure;
using Infrastructure.Persistence;
//using Infrastructure.Persistence;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace FunctionApi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            builder.Services.AddHealthChecks()
                .AddDbContextCheck<FractolDbContext>();

            builder.Services.AddScoped<IFractolDbContext>(provider => provider.GetService<FractolDbContext>());

        }
    }
}