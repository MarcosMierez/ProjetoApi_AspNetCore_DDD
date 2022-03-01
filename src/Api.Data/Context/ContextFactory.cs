using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Database=Api;User Id=sa;Password=92628861a;";
            var optionsBuilder = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
