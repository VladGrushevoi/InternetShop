namespace ShopApi.DataBaseContext.Repositories.CartDescriptions;

public sealed class CartDescriptions : CRUD_Repository<Entities.CartDescription>, ICartDescriptions
{
    public CartDescriptions(DataBaseContext context) : base(context)
    {
    }
}