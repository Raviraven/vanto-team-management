using Vanto.Domain.Members;
using Vanto.Domain.Teams;

namespace Vanto.Api.Contracts.Teams;

public sealed record TeamResponse(Guid Id, List<Member> Members)
{
    public TeamResponse(Team team) : this(team.Id, team.Members)
    {
    }
}