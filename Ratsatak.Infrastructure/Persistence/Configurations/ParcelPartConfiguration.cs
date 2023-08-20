using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratsatak.Domain.Parcels;
using Ratsatak.Domain.Parcels.Entities;
using Ratsatak.Domain.PossessionSheets;

namespace Ratsatak.Infrastructure.Persistence.Configurations;

public class ParcelPartConfiguration : IEntityTypeConfiguration<ParcelPart>
{
    public void Configure(EntityTypeBuilder<ParcelPart> builder)
    {
        builder.ToTable(nameof(ParcelPart), nameof(Parcel));

        builder.HasKey(pp => pp.Id);
        
        builder.Property(pp => pp.Id)
            .ValueGeneratedNever();

        builder.HasOne<PossessionSheet>()
            .WithMany()
            .HasForeignKey(pp => pp.PossessionSheetId);
    }
}