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
                Guid.Parse("869b0fd8-aeb0-4bee-af39-06d50fb6b3fc"),
                new List<Member> { }
            )
        );
    }
}