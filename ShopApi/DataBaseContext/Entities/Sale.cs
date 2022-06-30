namespace ShopApi.DataBaseContext.Entities;

public sealed class Sale : BaseEntity
{
    public Category Category { get; set; }
    public string Name { get; set; }
    public double PercentSale { get; set; }

    public ICollection<Product> Products { get; set; }
}