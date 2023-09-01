namespace MP5;

using Microsoft.EntityFrameworkCore;



public class Context : DbContext
{
    private readonly string _connectionString;
    
    public Context(string connectionString)
	{
        _connectionString = connectionString;
        /*
        Database.EnsureDeleted();
        Database.EnsureCreated();
        */
	}

    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Mechanic> Mechanics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
