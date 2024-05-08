using FluentValidation;

namespace Vanto.Application.Members.Commands.DeactivateMember;

public class DeactivateMemberCommandValidator : AbstractValidator<DeactivateMemberCommand>
{
    public DeactivateMemberCommandValidator()
    {
        RuleFor(n => n.Id)
            .NotEmpty().NotNull();
    }
}