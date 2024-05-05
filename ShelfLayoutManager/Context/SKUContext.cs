namespace  ShelfLayoutManager.Context;

using Microsoft.EntityFrameworkCore;
using ShelfLayoutManager.Entities;

public class SKUContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public SKUContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<SKU> SKUs { get; set; }
}