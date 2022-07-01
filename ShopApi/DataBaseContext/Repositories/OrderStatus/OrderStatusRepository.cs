namespace ShopApi.DataBaseContext.Repositories.OrderStatus;

public sealed class OrderStatusRepository : CRUD_Repository<Entities.OrderStatus>, IOrderStatusRepository
{
    public OrderStatusRepository(DataBaseContext context) : base(context)
    {
    }
}