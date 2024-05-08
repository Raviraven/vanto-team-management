using Vanto.Application.Repositories;
using Vanto.Domain.Members;

namespace Vanto.Infrastructure.Members;

public class MembersRepository : IMembersRepository
{
    private readonly List<Member> _members = new();
    
    public async Task<Member?> GetMemberByIdAsync(Guid id)
    {
        return await Task.FromResult(_members.FirstOrDefault(n => n.Id == id));
    }
    
    public Task AddMember(Member member)
    {
        _members.Add(member);
        return Task.CompletedTask;
    }
}