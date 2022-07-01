namespace ShopApi.DataBaseContext.Repositories.Sale;

public sealed class SaleRepository : CRUD_Repository<Entities.Sale>, ISaleRepository
{
    public SaleRepository(DataBaseContext context) : base(context)
    {
    }
}