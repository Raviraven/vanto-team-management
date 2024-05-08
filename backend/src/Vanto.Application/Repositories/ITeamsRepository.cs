using Vanto.Domain.Teams;

namespace Vanto.Application.Repositories;

public interface ITeamsRepository
{
    Task<Team?> GetTeamByIdAsync(Guid id);
}