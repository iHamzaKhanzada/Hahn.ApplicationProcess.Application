using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection SetUpDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<HahnDbContext>(options => options.UseInMemoryDatabase(databaseName: "HahnDb"));
            services.AddScoped<IHahnDbContext>(provider => provider.GetService<HahnDbContext>());
            services.AddTransient<ICountryManager, CountryManager>();

            return services;
        }
    }
}
