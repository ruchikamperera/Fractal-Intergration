using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace Application
{
    
        public static class DependencyInjection
        {
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {

               // services.AddAutoMapper(Assembly.GetExecutingAssembly());
              //  services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                services.AddMediatR(Assembly.GetExecutingAssembly());
                // services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
            }
        }
    }

