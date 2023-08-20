using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratsatak.Domain.Departments;
using Ratsatak.Domain.Municipalities;

namespace Ratsatak.Infrastructure.Persistence.Configurations;

public class MunicipalityConfigurations : IEntityTypeConfiguration<Municipality>
{
    public void Configure(EntityTypeBuilder<Municipality> builder)
    {
        ConfigureMunicipalityTable(builder);
    }

    private void ConfigureMunicipalityTable(EntityTypeBuilder<Municipality> builder)
    {
        builder.ToTable(nameof(Municipality), nameof(Municipality));

        builder.HasKey(m => m.Id);
        
        builder.Property(o => o.Id)
            .ValueGeneratedNever();

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(m => m.DepartmentId);

        builder.Property(m => m.Scraped)
            .HasDefaultValue(false);
    }
}