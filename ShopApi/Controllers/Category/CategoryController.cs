using ShopApi.Features.CQRS.Category.Commands;
using ShopApi.Features.CQRS.Category.Outputs;
using ShopApi.Features.CQRS.Category.Queries;
using ShopApi.Models;

namespace ShopApi.Controllers.Category;

[ApiController]
[Route("[controller]")]
public sealed class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException();

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(DataWithTotal<CategoryResponse>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAll([FromQuery] GetAllCategoryQuery query, CancellationToken token)
    {
        var result = await _mediator.Send(query, token);
        
        return Results.Ok(result);
    }

    [HttpGet("get/")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    public async Task<IResult> GetById([FromQuery]GetCategoryByIdQuery req, CancellationToken token)
    {
        var result = await _mediator.Send(req, token);
        
        return Results.Ok(result);
    }


    [HttpPost("add")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    public async Task<IResult> Add([FromBody] AddCategoryCommand req, CancellationToken token)
    {
        var entity = await _mediator.Send(req, token);

        return Results.Json(entity);
    }

    [HttpPatch("update")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status202Accepted)]
    [ProducesDefaultResponseType]
    public async Task<IResult> Update([FromBody] UpdateCategoryCommand req, CancellationToken token)
    {
        var result = await _mediator.Send(req, token);

        return  Results.Ok(result);
    }

    [HttpDelete("delete/")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    public async Task<IResult> Remove([FromQuery]RemoveCategoryCommand req, CancellationToken token)
    {
        var result = await _mediator.Send(req, token);
        
        return Results.Ok(result);
    }
}