using Microsoft.EntityFrameworkCore;
using Vanto.Application.Repositories;
using Vanto.Domain.Teams;
using Vanto.Infrastructure.Common;

namespace Vanto.Infrastructure.Teams;

public class TeamsRepository : ITeamsRepository
{
    private readonly VantoDbContext _dbContext;
    
    public TeamsRepository(VantoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Team?> GetTeamByIdAsync(Guid id)
    {
        return await _dbContext.Teams.FirstOrDefaultAsync(n => n.Id == id);
    }
}