namespace ShopApi.Features.CQRS.Category.Outputs;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public CategoryResponse(){}
    public CategoryResponse(DataBaseContext.Entities.Category category)
    {
        this.Id = category.Id;
        this.Name = category.Name;
    }
}