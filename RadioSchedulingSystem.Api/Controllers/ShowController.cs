using MediatR;
using Microsoft.AspNetCore.Mvc;
using RadioSchedulingSystem.Application.Commands;
using RadioSchedulingSystem.Application.Exceptions;
using RadioSchedulingSystem.Application.Queries;

namespace RadioSchedulingSystem.Api.Controllers;

[ApiController]
[Route("api/shows")]
public class ShowController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShowController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetShowById(id);
        var result = await _mediator.Send(query, cancellationToken);
        
        if (result is null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
    {
        var query = new GetShowByDate(date);
        var result = await _mediator.Send(query);
        
        if (!result.Any())
        {
            return NotFound();
        }
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateShow(CreateShow command)
    {
        try
        {
            var showId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = showId }, null);
        }
        catch (ShowConflictException)
        {
            return BadRequest("Show overlaps with an existing show.");
        }
    }
}