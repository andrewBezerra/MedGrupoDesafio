using MedGrupo.BackEnd.Core.Entities;
using MedGrupo.BackEnd.Core.Repositories;
using MedGrupo.BackEnd.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedGrupo.BackEnd.Data
{
    public static class StartupConfigurations
    {
        public static IServiceCollection AddRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("ContactsDbConnection"))
                .UseLazyLoadingProxies());

            return services;
        }
    }
}
