using ErrorOr;
using Vanto.Domain.Members;

namespace Vanto.Domain.Teams;

public sealed class Team
{
    public Guid Id { get; private init; }

    //private string Name { get; init; }
    public List<Member> Members { get; private init; }

    private Team(Guid id, List<Member> members)
    {
        Id = id;
        Members = members;
    }

    public static Team Create(Guid id, List<Member> members)
    {
        return new Team(id, members);
    }

    public ErrorOr<Success> AddMember(Member member)
    {
        if (Members.Any(n => n.Id == member.Id))
        {
            return Error.Conflict("Member already added to the team");
        }
        
        this.Members.Add(member);
        return Result.Success;
    }
}