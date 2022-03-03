using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Test;

public abstract class BaseTests
{
    public BaseTests()
    {

    }
}

public class DbTeste : IDisposable
{
    private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

    public ServiceProvider ServiceProvider { get; private set; }

    public DbTeste()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<MyContext>(o =>

            o.UseSqlServer($"Server=localhost;Database={dataBaseName};User Id=sa;Password=92628861a;"),
            ServiceLifetime.Transient
        );

        ServiceProvider = serviceCollection.BuildServiceProvider();

        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context.Database.EnsureCreated();
        }

    }

    public void Dispose()
    {
        using (var context = ServiceProvider.GetService<MyContext>())
        {
            context.Database.EnsureDeleted();
        }
    }
}
