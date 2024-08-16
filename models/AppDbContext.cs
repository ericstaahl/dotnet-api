using dotenv.net;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var envVars = DotEnv.Read();
        optionsBuilder.UseNpgsql(envVars["DB_CONNECTION"]).UseSnakeCaseNamingConvention();
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}
