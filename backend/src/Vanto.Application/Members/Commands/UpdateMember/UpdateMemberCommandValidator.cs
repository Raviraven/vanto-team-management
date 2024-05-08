using FluentValidation;

namespace Vanto.Application.Members.Commands.UpdateMember;

public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
{
    public UpdateMemberCommandValidator()
    {
        RuleFor(n => n.Id).NotEmpty().NotNull();
        
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