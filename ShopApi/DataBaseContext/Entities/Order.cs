namespace ShopApi.DataBaseContext.Entities;

public sealed class Order : BaseEntity
{
    public User User { get; set; }
    public DateOnly DateCreated { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public CartDescription CartDescription { get; set; }
}