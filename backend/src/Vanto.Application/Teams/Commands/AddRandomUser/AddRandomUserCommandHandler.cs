using System.Net.Http.Json;
using MediatR;
using ErrorOr;
using Vanto.Application.Common;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;
using Vanto.Domain.Teams;

namespace Vanto.Application.Teams.Commands.AddRandomUser;

public sealed record AddRandomUserCommand(Guid TeamId) : IRequest<ErrorOr<Team>>;

public class AddRandomUserCommandHandler : IRequestHandler<AddRandomUserCommand, ErrorOr<Team>>
{
    private readonly HttpClient _httpClient;
    private readonly ITeamsRepository _teamsRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public AddRandomUserCommandHandler(IHttpClientFactory httpClientFactory, ITeamsRepository teamsRepository, IUnitOfWork unitOfWork)
    {
        _httpClient = httpClientFactory.CreateClient();
        _teamsRepository = teamsRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ErrorOr<Team>> Handle(AddRandomUserCommand request, CancellationToken cancellationToken)
    {
        var team = await _teamsRepository.GetTeamByIdAsync(request.TeamId);
        
        if (team is null)
        {
            return Error.NotFound("Team not found"); // change error message? 
        }
        
        var result = await _httpClient.GetFromJsonAsync<RandomUserResponse>("https://randomuser.me/api/",
            cancellationToken: cancellationToken);
        
        if (result is null || result.Results.Length == 0)
        {
            return Error.NotFound("No random users found");
        }
        
        var randomUser = result.Results.First();
        
        var member = Member.Create(randomUser.Name.First, randomUser.Name.Last, randomUser.Email, randomUser.Phone,
            DateOnly.FromDateTime(randomUser.Registered.Date));
        
        var addMemberResult = team.AddMember(member);
        
        if (addMemberResult.IsError)
        {
            return addMemberResult.Errors;
        }
        
        await _unitOfWork.CommitChangesAsync();
        return team;
    }
}