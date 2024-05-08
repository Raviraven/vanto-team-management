using FluentValidation;

namespace Vanto.Application.Members.Queries.GetMember;

public class GetMemberQueryValidator : AbstractValidator<GetMemberQuery>
{
    public GetMemberQueryValidator()
    {
        RuleFor(n => n.Id).NotNull().NotEmpty();
    }
}