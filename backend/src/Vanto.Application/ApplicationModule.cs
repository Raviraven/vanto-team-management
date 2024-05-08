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
        
        // TODO: check registration of validators
        services.AddValidatorsFromAssemblyContaining(typeof(ApplicationModule));
        
        // services.AddMediatR(Assembly.GetExecutingAssembly());
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}