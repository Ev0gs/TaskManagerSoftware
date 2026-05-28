using Microsoft.EntityFrameworkCore;

public static class DBContextFactory
{
    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=tasks.db")
            .Options;

        return new AppDbContext(options);
    }
}