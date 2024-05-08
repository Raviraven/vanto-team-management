using FluentValidation;

namespace Vanto.Application.Members.Commands.ActivateMember;

public class ActivateMemberCommandValidator : AbstractValidator<ActivateMemberCommand>
{
    public ActivateMemberCommandValidator()
    {
        RuleFor(n => n.Id).NotEmpty().NotNull();
    }
}