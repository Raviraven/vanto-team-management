using Vanto.Application.Repositories;
using Vanto.Application.Teams.Queries.GetTeam;
using Vanto.Domain.Teams;

namespace Vanto.Application.Unit_Tests.Teams.Queries.GetTeam;

public class GetTeamQueryHandlerTests
{
    private readonly ITeamsRepository _teamsRepository;
    private readonly GetTeamQueryHandler _sut;
    
    public GetTeamQueryHandlerTests()
    {
        _teamsRepository = Substitute.For<ITeamsRepository>();
        _sut = new GetTeamQueryHandler(_teamsRepository);
    }
    
    [Fact]
    public async Task ShouldReturnTeam_WhenValidTeamIdIsProvided()
    {
        var teamId = Guid.NewGuid();
        
        // TODO: add and verify actual members
        var expectedTeam = Team.Create(Guid.NewGuid(), []);
        _teamsRepository.GetTeamByIdAsync(teamId).Returns(expectedTeam);
        
        var query = new GetTeamQuery(teamId);
        var result = await _sut.Handle(query, default);
        
        result.Value.Should().BeEquivalentTo(expectedTeam);
    }
    
    [Fact]
    public async Task ShouldReturnTeamNotFoundError_WhenTeamIdNotFound()
    {
        // Arrange
        var teamId = Guid.NewGuid();
        _teamsRepository.GetTeamByIdAsync(teamId).Returns((Team)null!);
        
        // Act
        var query = new GetTeamQuery(teamId);
        var result = await _sut.Handle(query, default);
        
        // Assert
        result.Errors.Should().BeEquivalentTo([Error.NotFound("Team not found")]);
    }
}