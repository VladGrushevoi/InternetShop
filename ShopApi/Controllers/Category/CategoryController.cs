namespace ShopApi.Controllers.Category;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException();
    
    [HttpPost]
    [ProducesResponseType(typeof(DataBaseContext.Entities.Category), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post([FromBody] AddCategoryCommand req, CancellationToken token)
    {
        DataBaseContext.Entities.Category entity = await _mediator.Send(req, token);

        return CreatedAtAction(nameof(Post), new {id = entity.Id}, entity);
    }
    
}