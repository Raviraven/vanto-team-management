using ErrorOr;
using MediatR;
using Vanto.Application.Repositories;
using Vanto.Domain.Teams;

namespace Vanto.Application.Teams.Queries.GetTeam;

public sealed record GetTeamQuery(Guid Id) : IRequest<ErrorOr<Team>>;

public sealed class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, ErrorOr<Team>>
{
    private readonly ITeamsRepository _teamsRepository;
    
    public GetTeamQueryHandler(ITeamsRepository teamsRepository)
    {
        _teamsRepository = teamsRepository;
    }
    
    public async Task<ErrorOr<Team>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
    {
        var team = await _teamsRepository.GetTeamByIdAsync(request.Id);
        
        if (team is null)
        {
            return Error.NotFound("Team not found");
        }
        
        return team;
    }
}