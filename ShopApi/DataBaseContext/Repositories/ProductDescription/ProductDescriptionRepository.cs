namespace ShopApi.DataBaseContext.Repositories.ProductDescription;

public sealed class ProductDescriptionRepository : CRUD_Repository<Entities.ProductDescription>, IProductDescriptionRepository
{
    public ProductDescriptionRepository(DataBaseContext context) : base(context)
    {
    }
}