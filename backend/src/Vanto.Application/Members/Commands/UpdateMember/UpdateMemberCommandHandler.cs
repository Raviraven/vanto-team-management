using MediatR;
using ErrorOr;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;

namespace Vanto.Application.Members.Commands.UpdateMember;

public sealed record UpdateMemberCommand(Guid Id, string FirstName, string LastName, string Email, string PhoneNumber)
    : IRequest<ErrorOr<Member>>;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, ErrorOr<Member>>
{
    private readonly IMembersRepository _membersRepository;
    
    public UpdateMemberCommandHandler(IMembersRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }
    
    public async Task<ErrorOr<Member>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _membersRepository.GetMemberByIdAsync(request.Id);
        
        if (member is null)
        {
            return Error.NotFound("Member not found");
        }
        
        member.Update(request.FirstName, request.LastName, request.Email, request.PhoneNumber);
        // save changes
        
        return member;
    }
}