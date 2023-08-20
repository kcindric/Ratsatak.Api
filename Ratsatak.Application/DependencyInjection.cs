using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Ratsatak.Application.Common.Helpers;

namespace Ratsatak.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped<IFileHelper, FileHelper>();

        return services;
    }
}