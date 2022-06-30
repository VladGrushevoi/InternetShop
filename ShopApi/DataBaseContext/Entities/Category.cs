namespace ShopApi.DataBaseContext.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
    // public Sale Sale { get; set; }
}