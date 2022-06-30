namespace ShopApi.DataBaseContext.Entities;


public sealed class CartDescription : BaseEntity
{
    public Product Product { get; set; }
    public int Count { get; set; }

    // public Order Order { get; set; }
}