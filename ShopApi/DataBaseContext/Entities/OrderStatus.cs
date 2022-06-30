namespace ShopApi.DataBaseContext.Entities;

public sealed class OrderStatus : BaseEntity
{
    public string Name { get; set; }
    public byte SysName { get; set; }

    public ICollection<Order> Orders { get; set; }
}