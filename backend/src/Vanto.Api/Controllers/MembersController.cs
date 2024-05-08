using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vanto.Api.Contracts.Members;
using Vanto.Application.Members.Commands.ActivateMember;
using Vanto.Application.Members.Commands.DeactivateMember;
using Vanto.Application.Members.Commands.UpdateMember;
using Vanto.Application.Members.Queries.GetMember;
using Vanto.Application.Teams.Queries.GetTeam;

namespace Vanto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : BasicController
    {
        private readonly ISender _mediator;
        
        public MembersController(ISender mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{memberId:guid}")]
        public async Task<IActionResult> GetMember(Guid memberId)
        {
            var query = new GetMemberQuery(memberId);
            var result = await _mediator.Send(query);
            
            return result.Match(
                val => Ok(new MemberResponse(val)),
                errors => Problem(ConvertErrorsToString(errors)) // TODO: handle differently
            );
        }
        
        // [HttpGet("{teamId:guid}")]
        // public async Task<IActionResult> ListTeamMembers(Guid teamId)
        // {
        //     var query = new GetTeamQuery(teamId);
        //     var result = await _mediator.Send(query);
        //     
        //     return result.Match(
        //         val => Ok(val.Members.ConvertAll(member => new MemberResponse(member))),
        //         errors => Problem(ConvertErrorsToString(errors)) // TODO: handle differently
        //     );
        // }
        
        // [HttpPost]
        // public async Task<IActionResult> CreateMember()
        // {
        //     var command = new CreateMemberCommand();
        //     
        //     return Ok();
        // }
        
        [HttpPost("{memberId:guid}/deactivate")]
        public async Task<IActionResult> DeactivateMember(Guid memberId)
        {
            var command = new DeactivateMemberCommand(memberId);
            var result = await _mediator.Send(command);
            
            return result.Match(
                val => Ok(new MemberResponse(val)),
                errors => Problem(ConvertErrorsToString(errors)));
        }
        
        [HttpPost("{memberId:guid}/activate")]
        public async Task<IActionResult> ActivateMember(Guid memberId)
        {
            var command = new ActivateMemberCommand(memberId);
            var result = await _mediator.Send(command);
            
            return result.Match(
                val => Ok(new MemberResponse(val)),
                errors => Problem(ConvertErrorsToString(errors))
            );
        }
        
        [HttpPost("{memberId:guid}/update")]
        public async Task<IActionResult> UpdateMember(Guid memberId, [FromBody] UpdateMemberRequest request)
        {
            var command = new UpdateMemberCommand(memberId, request.FirstName, request.LastName, request.Email,
                request.PhoneNumber);
            var result = await _mediator.Send(command);
            
            return result.Match(
                val => Ok(new MemberResponse(val)),
                errors => Problem(ConvertErrorsToString(errors))
            );
        }
    }
}