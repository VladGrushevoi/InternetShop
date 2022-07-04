using ShopApi.Features.CQRS.Role.Command;
using ShopApi.Features.CQRS.Role.Outputs;
using ShopApi.Features.CQRS.Role.Queries;
using ShopApi.Models;

namespace ShopApi.Controllers.Role;

[ApiController]
[Route("[controller]")]
public sealed class RoleController : ControllerBase
{
    private readonly ILogger<RoleController> _logger;
    private readonly IMediator _mediator;

    public RoleController(ILogger<RoleController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(DataWithTotal<RoleResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAll([FromQuery] GetRolesQuery query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        
        return Results.Ok(result);
    }

    [HttpGet("get/")]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status200OK)]
    public async Task<IResult> GetById([FromQuery] GetRoleByIdQuery query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        
        return Results.Ok(result);
    }

    [HttpPost("add")]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status201Created)]
    public async Task<IResult> Add([FromBody] AddRoleCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Json(result);
    }

    [HttpPatch("update")]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status201Created)]
    public async Task<IResult> Update([FromBody] UpdateRoleCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Ok(result);
    }

    [HttpDelete("delete/")]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status201Created)]
    public async Task<IResult> Delete([FromQuery] RemoveRoleCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Ok(result);
    }
}