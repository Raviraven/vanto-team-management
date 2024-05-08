using ErrorOr;
using MediatR;
using Vanto.Application.Repositories;
using Vanto.Domain.Members;

namespace Vanto.Application.Members.Queries.GetMember;

public sealed record GetMemberQuery(Guid Id) : IRequest<ErrorOr<Member>>;

public class GetMemberQueryHandler : IRequestHandler<GetMemberQuery, ErrorOr<Member>>
{
    private readonly IMembersRepository _membersRepository;
    
    public GetMemberQueryHandler(IMembersRepository membersRepository)
    {
        _membersRepository = membersRepository;
    }
    
    public async Task<ErrorOr<Member>> Handle(GetMemberQuery request, CancellationToken cancellationToken)
    {
        var member = await _membersRepository.GetMemberByIdAsync(request.Id);
        
        if (member is null)
        {
            return Error.NotFound("Team member not found");
        }
        
        return member;
    }
}