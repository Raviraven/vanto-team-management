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
        services.AddScoped<ITeamsRepository, TeamsRepository>();
        services.AddScoped<IMembersRepository, MembersRepository>();
        
        //TODO: change to proper
        services.AddScoped<IUnitOfWork, VantoDbContext>();
        
        return services;
    }
}