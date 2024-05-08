using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vanto.Api.Contracts.Members;
using Vanto.Api.Contracts.Teams;
using Vanto.Application.Teams.Commands.CreateAndAddTeamMember;
using Vanto.Application.Teams.Queries.GetTeam;

namespace Vanto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : BasicController
    {
        private readonly ISender _mediator;
        
        public TeamsController(ISender mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{teamId:guid}")]
        public async Task<IActionResult> GetTeam(Guid teamId)
        {
            var query = new GetTeamQuery(teamId);
            var result = await _mediator.Send(query);
            
            return result.Match(
                val => Ok(new TeamResponse(val)),
                err => Problem(string.Join(", ", err.Select(n => n.Description)))
            );
        }
        
        [HttpGet("{teamId:guid}/members")]
        public async Task<IActionResult> ListTeamMembers(Guid teamId)
        {
            var query = new GetTeamQuery(teamId);
            var result = await _mediator.Send(query);
            
            return result.Match(
                val => Ok(val.Members.ConvertAll(member => new MemberResponse(member))),
                errors => Problem(ConvertErrorsToString(errors))
            );
        }
        
        [HttpPost("{teamId:guid}/members")]
        public async Task<IActionResult> AddTeamMember(Guid teamId, [FromBody] CreateTeamMemberRequest request)
        {
            var command = new CreateAndAddTeamMemberCommand(teamId, request.FirstName, request.LastName, request.Email, request.PhoneNumber);
            var result = await _mediator.Send(command);
            
            return result.Match(
                val => CreatedAtAction(nameof(GetTeam), new { teamId }, new TeamResponse(val)),
                errors => Problem(ConvertErrorsToString(errors))
            );
        }
    }
}