using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ratsatak.Application.Persistence.Repositories;
using Ratsatak.Infrastructure.Persistence.DbContexts;
using Ratsatak.Infrastructure.Persistence.Repositories;

namespace Ratsatak.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddRepositories(configuration);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<RatsatakDbContext>(options =>
        {
            // options.UseSqlServer(
            //     "Server=localhost;Database=Ratsatak;User Id=sa;Password=KikiPass123!;Encrypt=false");
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
        });

        services.AddScoped<IOfficeRepository, OfficeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
        services.AddScoped<IParcelRepository, ParcelRepository>();
        services.AddScoped<IPossessionSheetRepository, PossessionSheetRepository>();
        services.AddScoped<ILandRegistryUnitRepository, LandRegistryUnitRepository>();

        return services;
    }
}