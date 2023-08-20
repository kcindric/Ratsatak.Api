using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratsatak.Domain.Offices;

namespace Ratsatak.Infrastructure.Persistence.Configurations;

public class OfficeConfigurations : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        ConfigureOfficeTable(builder);
    }

    private void ConfigureOfficeTable(EntityTypeBuilder<Office> builder)
    {
        builder.ToTable(nameof(Office), nameof(Office));

        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Id)
            .ValueGeneratedNever();
    }
}