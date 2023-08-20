using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratsatak.Domain.LandRegistryUnits;
using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Infrastructure.Persistence.Configurations;

public class LandRegistryUnitConfiguration : IEntityTypeConfiguration<LandRegistryUnit>
{
    public void Configure(EntityTypeBuilder<LandRegistryUnit> builder)
    {
        ConfigureLandRegistryUnitTable(builder);
    }

    private void ConfigureLandRegistryUnitTable(EntityTypeBuilder<LandRegistryUnit> builder)
    {
        builder.ToTable(nameof(LandRegistryUnit), nameof(LandRegistryUnit));

        builder.HasKey(lr => lr.Id);
        
        builder.Property(lr => lr.Id)
            .ValueGeneratedNever();

        builder.HasOne<Municipality>()
            .WithMany()
            .HasForeignKey(lr => lr.MunicipalityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}