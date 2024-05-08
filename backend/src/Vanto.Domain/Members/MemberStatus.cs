using Ardalis.SmartEnum;

namespace Vanto.Domain.Members;

public class MemberStatus : SmartEnum<MemberStatus>
{
    public static readonly MemberStatus Active = new(nameof(Active), 0);
    public static readonly MemberStatus Inactive = new(nameof(Inactive), 1);
    
    public MemberStatus(string name, int value) : base(name, value)
    {
    }
}