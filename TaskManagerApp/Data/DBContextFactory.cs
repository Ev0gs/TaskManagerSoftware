using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public static class DBContextFactory
{
    private static readonly string ConnectionString =
        $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.db")}";

    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(ConnectionString)
            .Options;

        return new AppDbContext(options);
    }
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args) => DBContextFactory.Create();
}