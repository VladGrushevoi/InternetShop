using ShopApi.Features.CQRS.OrderStatus.Command;
using ShopApi.Features.CQRS.OrderStatus.Outputs;
using ShopApi.Features.CQRS.OrderStatus.Queries;
using ShopApi.Models;

namespace ShopApi.Controllers.OrderStatus;
[ApiController]
[Route("[controller]")]
public class OrderStatusController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<OrderStatusController> _logger;

    public OrderStatusController(IMediator mediator, ILogger<OrderStatusController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(DataWithTotal<OrderStatusResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAll([FromQuery] GetAllOrderStatusQuery query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        
        return Results.Ok(result);
    }

    [HttpGet("get")]
    [ProducesResponseType(typeof(OrderStatusResponse), StatusCodes.Status200OK)]
    public async Task<IResult> GetById([FromQuery] GetByIdOrderStatusQuery query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        
        return Results.Ok(result);
    }

    [HttpPost("add")]
    [ProducesResponseType(typeof(OrderStatusResponse), StatusCodes.Status201Created)]
    public async Task<IResult> Add([FromBody] AddOrderStatusCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Json(result, statusCode:StatusCodes.Status201Created);
    }

    [HttpPatch("update")]
    [ProducesResponseType(typeof(OrderStatusResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Update(UpdateOrderStatusCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Ok(result);
    }

    [HttpDelete("delete")]
    [ProducesResponseType(typeof(OrderStatusResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Delete([FromQuery] RemoveOrderStatusCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Ok(result);
    }
}