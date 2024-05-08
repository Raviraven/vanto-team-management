using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vanto.Application.Common;
using Vanto.Application.Repositories;
using Vanto.Infrastructure.Common;
using Vanto.Infrastructure.Members;
using Vanto.Infrastructure.Teams;

namespace Vanto.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        services.AddDbContext<VantoDbContext>(opts => 
            opts.UseNpgsql("Host=localhost;Port=5432;Database=vanto;Username=postgres;Password=docker"));
        
        services.AddScoped<ITeamsRepository, TeamsRepository>();
        services.AddScoped<IMembersRepository, MembersRepository>();
        
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<VantoDbContext>());
        
        return services;
    }
}