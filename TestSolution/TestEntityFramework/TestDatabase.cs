using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestEntityFramework
{
  public static class TestDatabase
  {
    private const string DefConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Test;Trusted_Connection=True;MultipleActiveResultSets=true";

    public static TestDbContext GetDbContext(string connectionString = null)
    {
      return new TestDbContext(GetSqlServerTestOptions(connectionString ?? DefConnectionString));
    }

    private static DbContextOptions<TestDbContext> GetSqlServerTestOptions(string conn)
    {
      var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkSqlServer()
        .BuildServiceProvider();

      var builder = new DbContextOptionsBuilder<TestDbContext>()
        .EnableSensitiveDataLogging()
        .UseSqlServer(conn)
        .UseInternalServiceProvider(serviceProvider);

      return builder.Options;
    }


  }
}
