using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicationProcess.February2021.Domain.Behaviors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain
{
    public static class DependencyInjection
    {

        public static IServiceCollection SetUpDependencies(this IServiceCollection services)
        {
            //services.AddTransient<IAssetService, AssetService>();
            //services.AddTransient<IValidator<AssetVM>, AssetVMValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
