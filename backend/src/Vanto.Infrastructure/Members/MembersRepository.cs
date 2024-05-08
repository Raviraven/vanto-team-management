using Microsoft.EntityFrameworkCore;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;
using Vanto.Infrastructure.Common;

namespace Vanto.Infrastructure.Members;

public class MembersRepository : IMembersRepository
{
    private readonly VantoDbContext _dbContext;
    
    public MembersRepository(VantoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Member?> GetMemberByIdAsync(Guid id)
    {
        return await _dbContext.Members.FirstOrDefaultAsync(n => n.Id == id);
    }
    
    public Task AddMember(Member member)
    {
        _dbContext.Members.Add(member);
        return Task.CompletedTask;
    }
}