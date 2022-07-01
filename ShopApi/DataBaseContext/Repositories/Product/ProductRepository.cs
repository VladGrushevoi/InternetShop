namespace ShopApi.DataBaseContext.Repositories.Product;

public sealed class ProductRepository : CRUD_Repository<Entities.Product>, IProductRepository
{
    public ProductRepository(DataBaseContext context) : base(context)
    {
    }
}