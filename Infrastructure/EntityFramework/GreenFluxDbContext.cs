using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework;

public class MicroSampDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public MicroSampDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Group> Products { get; set; }
    public virtual DbSet<ChargeStation> ChargeStations { get; set; }
    public virtual DbSet<Connector> Connectors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //The schema for the database
        const string schema = "grnflx";
        base.OnModelCreating(modelBuilder);

        //Setting all table names and applying all configurations from configuration folder
        modelBuilder.Entity<Group>().ToTable(nameof(Group), schema);
        modelBuilder.Entity<ChargeStation>().ToTable(nameof(ChargeStation), schema);
        modelBuilder.Entity<Connector>().ToTable(nameof(Connector), schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MicroSampDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }
}