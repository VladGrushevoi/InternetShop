namespace ShopApi.DataBaseContext.Entities;

public sealed class Comment : BaseEntity
{
    public string Content { get; set; }
    public string? Advantages { get; set; }
    public string? Disadvantages { get; set; }
    public double Raiting { get; set; }

    public ProductDescription? ProductDescription { get; set; }
    public User User { get; set; }
}