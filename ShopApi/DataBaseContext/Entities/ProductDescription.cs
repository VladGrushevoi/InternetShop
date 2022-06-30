namespace ShopApi.DataBaseContext.Entities;

public sealed class ProductDescription : BaseEntity
{
    public string Brand { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public decimal Price { get; set; }
    public string? AdditionalCharacteristic { get; set; }

    public ICollection<Comment> Comments { get; set; }
    // public Product Product { get; set; }
}