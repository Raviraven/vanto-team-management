using ErrorOr;
using MediatR;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;

namespace Vanto.Application.Members.Commands.ActivateMember;

public sealed record ActivateMemberCommand(Guid Id) : IRequest<ErrorOr<Member>>;

public class ActivateMemberCommandHandler : IRequestHandler<ActivateMemberCommand, ErrorOr<Member>>
{
    private readonly IMembersRepository _membersRepository;
    
    public ActivateMemberCommandHandler(IMembersRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }
    
    public async Task<ErrorOr<Member>> Handle(ActivateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _membersRepository.GetMemberByIdAsync(request.Id);
        
        if (member is null)
        {
            return Error.NotFound("Member not found");
        }
        
        member.Activate();
        // commit changes
        
        return member;
    }
}