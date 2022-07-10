using ShopApi.Features.CQRS.User.Commands;
using ShopApi.Features.CQRS.User.Outputs;
using ShopApi.Features.CQRS.User.Queries;
using ShopApi.Models;

namespace ShopApi.Controllers.User;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(DataWithTotal<UserResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAll([FromQuery] GetAllUserQuery query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        
        return Results.Ok(result);
    }

    [HttpGet("get/")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<IResult> GetById([FromQuery] GetUserByIdQuery query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        
        return Results.Ok(result);
    }
    
    [HttpPost("add")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    public async Task<IResult> Add([FromBody] AddUserCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Json(result,  statusCode: StatusCodes.Status201Created);
    }

    [HttpPatch("update")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Update([FromBody] UpdateUserCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Ok(result);
    }
    
    [HttpDelete("delete")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Delete ([FromQuery] RemoveUserCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);

        return Results.Ok(result);
    }
}