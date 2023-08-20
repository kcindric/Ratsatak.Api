using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratsatak.Domain.Municipalities;
using Ratsatak.Domain.PossessionSheets;
using Ratsatak.Domain.PossessionSheets.ValueObjects;

namespace Ratsatak.Infrastructure.Persistence.Configurations;

public class PossessionSheetConfigurations : IEntityTypeConfiguration<PossessionSheet>
{
    public void Configure(EntityTypeBuilder<PossessionSheet> builder)
    {
        ConfigurePossessionSheetTable(builder);
        ConfigurePossessorsTable(builder);
    }

    private void ConfigurePossessionSheetTable(EntityTypeBuilder<PossessionSheet> builder)
    {
        builder.ToTable(nameof(PossessionSheet), nameof(PossessionSheet));

        builder.HasKey(ps => ps.Id);

        builder.Property(ps => ps.Id)
            .ValueGeneratedNever();

        builder.HasOne<Municipality>()
            .WithMany()
            .HasForeignKey(ps => ps.MunicipalityId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(ps => ps.IsHarmonized)
            .HasDefaultValue(false);
    }

    private void ConfigurePossessorsTable(EntityTypeBuilder<PossessionSheet> builder)
    {
        builder.OwnsMany(ps => ps.Possessors, possessorsBuilder =>
        {
            possessorsBuilder.ToTable(nameof(Possessor), nameof(PossessionSheet));

            possessorsBuilder.WithOwner().HasForeignKey("PossessionSheetId");

            possessorsBuilder.HasKey("Id");
        });

        builder.Metadata.FindNavigation(nameof(PossessionSheet.Possessors))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}