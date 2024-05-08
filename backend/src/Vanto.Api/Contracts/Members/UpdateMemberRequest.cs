namespace Vanto.Api.Contracts.Members;

public sealed record UpdateMemberRequest(Guid Id, string FirstName, string LastName, string Email, string PhoneNumber);