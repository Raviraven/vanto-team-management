using ErrorOr;
using MediatR;
using Vanto.Application.Common;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;

namespace Vanto.Application.Members.Commands.DeactivateMember;

public sealed record DeactivateMemberCommand(Guid Id) : IRequest<ErrorOr<Member>>;

public class DeactivateMemberCommandHandler : IRequestHandler<DeactivateMemberCommand, ErrorOr<Member>>
{
    private readonly IMembersRepository _membersRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeactivateMemberCommandHandler(IMembersRepository membersRepository, IUnitOfWork unitOfWork)
    {
        _membersRepository = membersRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ErrorOr<Member>> Handle(DeactivateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _membersRepository.GetMemberByIdAsync(request.Id);
        
        if (member is null)
        {
            return Error.NotFound("Member not found");
        }
        
        member.Deactivate();
        await _unitOfWork.CommitChangesAsync();
        
        return member;
    }
}