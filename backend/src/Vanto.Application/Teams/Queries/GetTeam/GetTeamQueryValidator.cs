using FluentValidation;

namespace Vanto.Application.Teams.Queries.GetTeam;

public class GetTeamQueryValidator : AbstractValidator<GetTeamQuery>
{
    public GetTeamQueryValidator()
    {
        RuleFor(n => n.Id).NotNull().NotEmpty();
    }
}