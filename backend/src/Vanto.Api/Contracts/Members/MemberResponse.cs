using Vanto.Domain.Members;

namespace Vanto.Api.Contracts.Members;

public sealed record MemberResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Status,
    DateOnly CreatedAt)
{
    public MemberResponse(Member member) :
        this(member.Id, member.FirstName, member.LastName, member.Email, member.PhoneNumber, member.Status.Name,
            member.CreatedAt)
    {
    }
}