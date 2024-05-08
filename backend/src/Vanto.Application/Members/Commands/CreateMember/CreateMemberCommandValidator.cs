using FluentValidation;

namespace Vanto.Application.Members.Commands.CreateMember;

public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator()
    {
        RuleFor(n => n.FirstName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(n => n.LastName)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(n => n.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(n => n.PhoneNumber).NotEmpty().MaximumLength(15);
    }
}