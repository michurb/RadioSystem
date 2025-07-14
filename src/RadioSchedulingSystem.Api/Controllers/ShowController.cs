using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RadioSchedulingSystem.Application.Commands;
using RadioSchedulingSystem.Application.DTO;
using RadioSchedulingSystem.Application.Exceptions;
using RadioSchedulingSystem.Application.Queries;

namespace RadioSchedulingSystem.Api.Controllers;

[ApiController]
[Route("api/shows")]
public class ShowController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateShowDto> _validator;
    private readonly ILogger<ShowController> _logger;

    public ShowController(IMediator mediator, IValidator<CreateShowDto> validator, ILogger<ShowController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetShowById(id);
        var result = await _mediator.Send(query, cancellationToken);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
    {
        var query = new GetShowByDate(date);
        var result = await _mediator.Send(query);

        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShow(CreateShow command)
    {
        var validator = _validator.Validate(command.dto);
        if (!validator.IsValid) return BadRequest(validator.Errors);

        try
        {
            var showId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = showId }, null);
        }
        catch (ShowConflictException)
        {
            _logger.LogError("Show overlaps with an existing show. Command: {@Command}", command);
            return BadRequest("Show overlaps with an existing show.");
        }
    }
}