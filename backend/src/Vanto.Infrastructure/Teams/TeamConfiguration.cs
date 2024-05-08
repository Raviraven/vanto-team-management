using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vanto.Domain.Members;
using Vanto.Domain.Teams;

namespace Vanto.Infrastructure.Teams;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(n => n.Id);
        
        builder.Property(n => n.Id)
            .ValueGeneratedNever();
        
        builder.ToTable("Teams", "Vanto");
        
        
        // temporary data
        builder.HasData(Team.Create(
            Guid.Parse("869b0fd8-aeb0-4bee-af39-06d50fb6b3fc"),
            new List<Member> { }
        ));
    }
}