namespace Vanto.Application.Common;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}