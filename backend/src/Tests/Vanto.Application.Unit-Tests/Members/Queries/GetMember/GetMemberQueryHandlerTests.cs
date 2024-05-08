using Vanto.Application.Members.Queries.GetMember;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;

namespace Vanto.Application.Unit_Tests.Members.Queries.GetMember;

public class GetMemberQueryHandlerTests
{
    private readonly IMembersRepository _membersRepository;
    private readonly GetMemberQueryHandler _sut;
    
    public GetMemberQueryHandlerTests()
    {
        _membersRepository = Substitute.For<IMembersRepository>();
        _sut = new GetMemberQueryHandler(_membersRepository);
    }
    
    [Fact]
    public async Task ShouldReturnMember_WhenValidMemberIdIsProvided()
    {
        var memberId = Guid.NewGuid();
        // TODO: add MemberBuilder
        var expectedMember = Member.Create("John", "Doe", "john.doe@test.com", "555-222-333",
            DateOnly.FromDateTime(new DateTime(2024, 6, 8)));
        _membersRepository.GetMemberByIdAsync(memberId).Returns(expectedMember);
        
        var query = new GetMemberQuery(memberId);
        var result = await _sut.Handle(query, default);
        
        result.Value.Should().BeEquivalentTo(expectedMember);
    }
    
    [Fact]
    public async Task ShouldReturnTEamMemberNotFoundError_WhenMemberNotFound()
    {
        var memberId = Guid.NewGuid();
        _membersRepository.GetMemberByIdAsync(memberId).Returns((Member)null!);
        
        var query = new GetMemberQuery(memberId);
        var result = await _sut.Handle(query, default);
        
        result.Errors.Should().BeEquivalentTo(new List<Error> { Error.NotFound("Team member not found") });
    }
}