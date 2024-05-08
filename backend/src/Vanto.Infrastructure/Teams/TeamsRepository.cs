using Vanto.Application.Repositories;
using Vanto.Domain.Members;
using Vanto.Domain.Teams;

namespace Vanto.Infrastructure.Teams;

public class TeamsRepository : ITeamsRepository
{
    private readonly List<Team> _teams = new();
    
    public async Task<Team?> GetTeamByIdAsync(Guid id)
    {
        return await Task.FromResult(
            Team.Create(
                Guid.NewGuid(),
                new List<Member> { }
            )
        );
    }
}