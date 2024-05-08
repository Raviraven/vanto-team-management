namespace Vanto.Domain.Members;

public sealed class Member
{
    // left for EF Core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Member()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
    
    private Member(Guid id, string firstName, string lastName, string email, string phoneNumber, MemberStatus status,
        DateOnly createdAt)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Status = status;
        CreatedAt = createdAt;
    }
    
    public static Member Create(string firstName, string lastName, string email, string phoneNumber, DateOnly createdAt)
    {
        return new Member(Guid.NewGuid(), firstName, lastName, email, phoneNumber, MemberStatus.Active, createdAt);
    }
    
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public MemberStatus Status { get; private set; }
    public DateOnly CreatedAt { get; private set; }
    
    public void Activate()
    {
        Status = MemberStatus.Active;
    }
    
    public void Deactivate()
    {
        Status = MemberStatus.Inactive;
    }
    
    public void Update(string firstName, string lastName, string email, string phoneNumber)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }
}