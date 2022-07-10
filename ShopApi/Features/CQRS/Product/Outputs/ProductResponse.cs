using ShopApi.Features.CQRS.Category.Outputs;

namespace ShopApi.Features.CQRS.Product.Outputs;

public class ProductResponse
{
    public Guid Id { get; set; }
    public CategoryResponse? Category { get; set; }
    public ProductDescriptionResponse? ProductDescription { get; set; }
    // public Sale? Sale { get; set; } TODO
    public DateOnly DateCreated { get; set; }
    public int  Count { get; set; }
    
    public ProductResponse(){}

    public ProductResponse(DataBaseContext.Entities.Product entity)
    {
        Id = entity.Id;
        Category = entity.Category is not null ? new CategoryResponse(entity.Category) : null;
        this.ProductDescription = entity.ProductDescription is not null
            ? new ProductDescriptionResponse(entity.ProductDescription)
            : null;
        DateCreated = entity.DateCreated;
        Count = entity.Count;
    }
}

public sealed class ProductDescriptionResponse
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public decimal Price { get; set; }
    public string? AdditionalCharacteristic { get; set; }

    public ProductDescriptionResponse()
    {
        
    }
    public ProductDescriptionResponse(ProductDescription entity)
    {
        Id = entity.Id;
        Brand = entity.Brand;
        Name = entity.Name;
        Model = entity.Model;
        Year = entity.Year;
        Price = entity.Price;
        AdditionalCharacteristic = entity.AdditionalCharacteristic;
    }
} 