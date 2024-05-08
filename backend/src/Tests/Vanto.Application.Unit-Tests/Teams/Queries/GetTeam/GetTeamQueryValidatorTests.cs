using FluentValidation.TestHelper;
using Vanto.Application.Teams.Queries.GetTeam;

namespace Vanto.Application.Unit_Tests.Teams.Queries.GetTeam;

public class GetTeamQueryValidatorTests
{
    [Fact]
    public void ShouldPassValidation_When_IdIsNotEmpty()
    {
        var query = new GetTeamQuery(Guid.NewGuid());
        var validator = new GetTeamQueryValidator();

        var result = validator.TestValidate(query);

        result.ShouldNotHaveAnyValidationErrors();
    }
    
    [Fact]
    public void ShouldHaveValidationError_When_IdIsEmpty()
    {
        var query = new GetTeamQuery(Guid.Empty);
        var validator = new GetTeamQueryValidator();

        var result = validator.TestValidate(query);

        result.ShouldHaveValidationErrorFor(x => x.Id);
    }
}