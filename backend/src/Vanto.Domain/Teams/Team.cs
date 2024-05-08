using Vanto.Domain.Members;

namespace Vanto.Domain.Teams;

public sealed class Team
{
    private Guid Id { get; init; }

    //private string Name { get; init; }
    private List<Member> Members { get; init; }

    private Team(Guid id, List<Member> members)
    {
        Id = id;
        Members = members;
    }

    public static Team Create(Guid id, List<Member> members)
    {
        return new Team(id, members);
    }

    public void AddMember(Member member)
    {
        this.Members.Add(member);
    }
}