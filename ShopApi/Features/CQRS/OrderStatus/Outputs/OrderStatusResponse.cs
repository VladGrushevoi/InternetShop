namespace ShopApi.Features.CQRS.OrderStatus.Outputs;

public sealed class OrderStatusResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte SysName { get; set; }
    
    public OrderStatusResponse(){}

    public OrderStatusResponse(DataBaseContext.Entities.OrderStatus entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        SysName = entity.SysName;
    }
}