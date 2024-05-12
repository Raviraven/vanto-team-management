using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Vanto.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(opts =>
        {
            opts.RegisterServicesFromAssemblyContaining(typeof(ApplicationModule));
        });
        
        services.AddValidatorsFromAssemblyContaining(typeof(ApplicationModule));
        
        services.AddHttpClient();
        
        return services;
    }
}