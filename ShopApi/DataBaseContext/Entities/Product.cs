namespace ShopApi.DataBaseContext.Entities;

public sealed class Product : BaseEntity
{
    public Category Category { get; set; }
    public ProductDescription ProductDescription { get; set; }
    public Sale? Sale { get; set; }
    public DateOnly DateCreated { get; set; }
    public int  Count { get; set; }

    public ICollection<CartDescription> CartDecriptions { get; set; }
}