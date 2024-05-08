using ErrorOr;
using Vanto.Domain.Members;

namespace Vanto.Domain.Teams;

public sealed class Team
{
    public Guid Id { get; private init; }

    //private string Name { get; init; }
    public List<Member> Members { get; private init; }
    
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Team()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Members = new List<Member>();
    }
    
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