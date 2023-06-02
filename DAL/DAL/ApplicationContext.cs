using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationContext : DbContext
{
    public DbSet<Baker> Client { get; set; }
    public DbSet<Measure> Measure { get; set; }
    public DbSet<Opens> Opens { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Work> Work { get; set; }
    public DbSet<Worker> Worker { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        string connectionString = config.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }

}
