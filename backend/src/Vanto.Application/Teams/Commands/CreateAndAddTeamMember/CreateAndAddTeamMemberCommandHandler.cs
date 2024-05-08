using ErrorOr;
using MediatR;
using Vanto.Application.Common;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;
using Vanto.Domain.Teams;

namespace Vanto.Application.Teams.Commands.CreateAndAddTeamMember;

public sealed record CreateAndAddTeamMemberCommand(
    Guid TeamId,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber) : IRequest<ErrorOr<Team>>;

public class CreateAndAddTeamMemberCommandHandler : IRequestHandler<CreateAndAddTeamMemberCommand, ErrorOr<Team>>
{
    private readonly ITeamsRepository _teamsRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateAndAddTeamMemberCommandHandler(ITeamsRepository teamsRepository, IUnitOfWork unitOfWork)
    {
        _teamsRepository = teamsRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ErrorOr<Team>> Handle(CreateAndAddTeamMemberCommand request, CancellationToken cancellationToken)
    {
        var team = await _teamsRepository.GetTeamByIdAsync(request.TeamId);
        
        if (team is null)
        {
            return Error.NotFound("Team not found"); // change error message? 
        }
        
        var member = Member.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber,
            DateOnly.FromDateTime(DateTime.UtcNow));
        
        var addMemberResult = team.AddMember(member);
        
        if (addMemberResult.IsError)
        {
            return addMemberResult.Errors;
        }
        
        // update team repo method?
        await _unitOfWork.CommitChangesAsync();
        
        return team;
    }
}