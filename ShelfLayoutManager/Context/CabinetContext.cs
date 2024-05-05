namespace  ShelfLayoutManager.Context;

using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Entities;



public class CabinetContext : DbContext
{

    protected readonly IConfiguration Configuration;
    public CabinetContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<Cabinet> Cabinets { get; set; }
    public DbSet<Row> Rows { get; set; }
    public DbSet<Lane> Lanes { get; set; }
}
