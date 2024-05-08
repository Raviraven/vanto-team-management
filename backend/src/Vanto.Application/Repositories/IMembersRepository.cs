using Vanto.Domain.Members;

namespace Vanto.Application.Repositories;

public interface IMembersRepository
{
    Task<Member?> GetMemberByIdAsync(Guid id);
    Task AddMember(Member member);
}