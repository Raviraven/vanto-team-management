using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Vanto.Application.Common;
using Vanto.Domain.Members;
using Vanto.Domain.Teams;

namespace Vanto.Infrastructure.Common;

public class VantoDbContext : DbContext, IUnitOfWork //: DbContext
{
    public VantoDbContext()
    {
    }
    
    public VantoDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public async Task CommitChangesAsync()
    {
        await SaveChangesAsync();
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql("Host=localhost;Database=vanto;Username=postgres;Password=postgres");
    // }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Team> Teams { get; set; }
    
    public DbSet<Member> Members { get; set; }
}