using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ratsatak.Domain.Departments;
using Ratsatak.Domain.Offices;

namespace Ratsatak.Infrastructure.Persistence.Configurations;

public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        ConfigureDepartmentTable(builder);
    }

    private void ConfigureDepartmentTable(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(nameof(Department), nameof(Department));

        builder.HasKey(d => d.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedNever();

        builder.HasOne<Office>()
            .WithMany()
            .HasForeignKey(d => d.OfficeId);
    }
}