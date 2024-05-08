using ErrorOr;
using MediatR;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;

namespace Vanto.Application.Members.Commands.CreateMember;

public sealed record CreateMemberCommand(string FirstName, string LastName, string Email, string PhoneNumber)
    : IRequest<ErrorOr<Member>>; // IRequest<ErrorOr<Success>>;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, ErrorOr<Member>>
{
    private readonly IMembersRepository _membersRepository;
    
    public CreateMemberCommandHandler(IMembersRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }
    
    public async Task<ErrorOr<Member>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = Member.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber,
            DateOnly.FromDateTime(DateTime.UtcNow));
        
        await _membersRepository.AddMember(member);
        // commit changes
        
        return member;
    }
}