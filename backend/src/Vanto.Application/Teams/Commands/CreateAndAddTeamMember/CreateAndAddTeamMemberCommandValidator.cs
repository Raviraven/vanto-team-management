using FluentValidation;

namespace Vanto.Application.Teams.Commands.CreateAndAddTeamMember;

public class CreateAndAddTeamMemberCommandValidator : AbstractValidator<CreateAndAddTeamMemberCommand>
{
    public CreateAndAddTeamMemberCommandValidator()
    {
        RuleFor(n => n.FirstName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(n => n.LastName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(n => n.Email).NotEmpty();
        
        RuleFor(n => n.PhoneNumber)
            .NotEmpty()
            .MaximumLength(15);
        
        RuleFor(n => n.TeamId).NotEmpty().NotNull();
    }
}