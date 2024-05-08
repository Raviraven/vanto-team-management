using Vanto.Application.Common;

namespace Vanto.Infrastructure.Common;

public class VantoDbContext : IUnitOfWork //: DbContext
{
    public Task CommitChangesAsync()
    {
        // TODO: Implement CommitChangesAsync
        return Task.CompletedTask;
    }
}