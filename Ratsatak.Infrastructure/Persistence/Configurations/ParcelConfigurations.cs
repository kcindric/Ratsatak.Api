using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratsatak.Domain.LandRegistryUnits;
using Ratsatak.Domain.Municipalities;
using Ratsatak.Domain.Parcels;

namespace Ratsatak.Infrastructure.Persistence.Configurations;

public class ParcelConfigurations : IEntityTypeConfiguration<Parcel>
{
    public void Configure(EntityTypeBuilder<Parcel> builder)
    {
        ConfigureParcelTable(builder);
    }

    private void ConfigureParcelTable(EntityTypeBuilder<Parcel> builder)
    {
        builder.ToTable(nameof(Parcel), nameof(Parcel));

        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.HasOne<Municipality>()
            .WithMany()
            .HasForeignKey(p => p.MunicipalityId)
            .IsRequired();

        builder.HasMany(p => p.ParcelParts)
            .WithOne()
            .HasForeignKey(pp => pp.ParcelId);

        builder.HasOne<LandRegistryUnit>()
            .WithMany()
            .HasForeignKey(lr => lr.LrUnitId);

        builder.Metadata.FindNavigation(nameof(Parcel.ParcelParts))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}