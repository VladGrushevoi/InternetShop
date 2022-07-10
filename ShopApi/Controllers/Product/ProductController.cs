using ShopApi.Features.CQRS.Product.Command;
using ShopApi.Features.CQRS.Product.Outputs;
using ShopApi.Features.CQRS.Product.Queries;
using ShopApi.Models;

namespace ShopApi.Controllers.Product;

[ApiController]
[Route("[controller]")]
public sealed class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IMediator mediator, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(DataWithTotal<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAll([FromQuery] GetAllProductQuery query, CancellationToken cts)
    {
        var result = await _mediator.Send(query, cts);
        
        return Results.Ok(result);
    }

    [HttpPost("add")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    public async Task<IResult> Add([FromBody] AddProductCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);

        return Results.Json(result, statusCode: StatusCodes.Status201Created);
    }

    [HttpPatch("update")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Update([FromBody] UpdateProductCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);
        
        return Results.Ok(result);
    }

    [HttpDelete("delete")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Delete([FromQuery] RemoveProductCommand command, CancellationToken cts)
    {
        var result = await _mediator.Send(command, cts);

        return Results.Ok(result);
    }
}