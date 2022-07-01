namespace ShopApi.DataBaseContext.Repositories.Category;

public sealed class CategoryRepository : CRUD_Repository<Entities.Category>, ICategoryRepository
{
    public CategoryRepository(DataBaseContext context) : base(context)
    {
    }
}