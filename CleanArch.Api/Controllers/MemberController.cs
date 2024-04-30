using CleanArch.Application.Members.Commands;
using CleanArch.Application.Members.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;
    public MemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMember(CreateMemberCommand command)
    {
        var createdMember = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateMember), new { id = createdMember.Id }, createdMember);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
    {
        command.Id = id;
        var updatedMember = await _mediator.Send(command);
        return updatedMember != null ? Ok(updatedMember) : NotFound("Member not found.");
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(int id)
    {
        var command = new DeleteMemberCommand { Id = id };
        var deletedMember = await _mediator.Send(command);
        return deletedMember != null ? Ok(deletedMember) : NotFound("Member not found.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMemberById(int id)
    {
        var query = new GetMemberByIdQuery { Id = id };
        var member = await _mediator.Send(query);
        return member != null ? Ok(member) : NotFound("Member not found.");
    }

    [HttpGet()]
    public async Task<IActionResult> GetMembers()
    {
        var query = new GetMembersQuery();
        var members = await _mediator.Send(query);
        return members.Count() == 0 ? NoContent()  :Ok(members);
    }
}
