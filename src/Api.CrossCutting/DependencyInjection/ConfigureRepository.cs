using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "sqlServer".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
            );
            }
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=localhost;Database=Api;User Id=sa;Password=92628861a;")
            );

        }
    }
}
