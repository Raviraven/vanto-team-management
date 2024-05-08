namespace Vanto.Api.Contracts.Teams;

public sealed record CreateTeamMemberRequest(
    //Guid TeamId,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber);