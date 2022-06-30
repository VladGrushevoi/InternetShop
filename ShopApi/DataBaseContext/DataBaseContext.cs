namespace ShopApi.DataBaseContext;

public sealed class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> opt) : base(opt)
    {
        Database.EnsureCreatedAsync();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CartDescription> CartDescriptions { get; set; }
    public DbSet<ProductDescription> ProductDescriptions { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
}