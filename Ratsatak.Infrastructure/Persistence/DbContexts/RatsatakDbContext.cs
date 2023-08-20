using Microsoft.EntityFrameworkCore;
using Ratsatak.Domain.Departments;
using Ratsatak.Domain.LandRegistryUnits;
using Ratsatak.Domain.Municipalities;
using Ratsatak.Domain.Offices;
using Ratsatak.Domain.Parcels;
using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Infrastructure.Persistence.DbContexts;

public class RatsatakDbContext : DbContext
{
    public RatsatakDbContext(DbContextOptions<RatsatakDbContext> options) : base(options)
    {
    }

    public DbSet<Office> Offices { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Municipality> Municipalities { get; set; } = null!;
    public DbSet<PossessionSheet> PossessionSheets { get; set; } = null!;
    public DbSet<LandRegistryUnit> LandRegistryUnits  { get; set; } = null!;
    public DbSet<Parcel> Parcels { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(RatsatakDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}