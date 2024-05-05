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

}

public class RowContext : DbContext
{

    protected readonly IConfiguration Configuration;
    public RowContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<Row> Rows { get; set; }
    public DbSet<Lane> Lanes { get; set; }
}

public class LaneContext : DbContext
{

    protected readonly IConfiguration Configuration;
    public LaneContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<Lane> Lanes { get; set; }
}

public class PositionContext : DbContext
{

    protected readonly IConfiguration Configuration;
    public PositionContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<Position> Positions { get; set; }
}

public class SizeContext : DbContext
{

    protected readonly IConfiguration Configuration;
    public SizeContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<Size> Sizes { get; set; }
}
