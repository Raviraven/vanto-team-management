using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vanto.Domain.Members;

namespace Vanto.Infrastructure.Members;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(n => n.Id);
        
        builder.Property(n => n.Id)
            .ValueGeneratedNever();
        
        builder.Property(n => n.Status)
            .HasConversion(
                status => status.Name,
                name => MemberStatus.FromName(name, true)
            );
        
        builder.ToTable("Members", "Vanto");
    }
}