namespace ShopApi.DataBaseContext.Repositories.Order;

public sealed class OrderRepository : CRUD_Repository<Entities.Order>, IOrderRepository
{
    public OrderRepository(DataBaseContext context) : base(context)
    {
    }
}