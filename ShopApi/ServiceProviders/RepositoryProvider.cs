using ShopApi.DataBaseContext.Repositories.CartDescriptions;
using ShopApi.DataBaseContext.Repositories.Category;
using ShopApi.DataBaseContext.Repositories.Comment;
using ShopApi.DataBaseContext.Repositories.Order;
using ShopApi.DataBaseContext.Repositories.OrderStatus;
using ShopApi.DataBaseContext.Repositories.Product;
using ShopApi.DataBaseContext.Repositories.ProductDescription;
using ShopApi.DataBaseContext.Repositories.Role;
using ShopApi.DataBaseContext.Repositories.Sale;

namespace ShopApi.ServiceProviders;

public static class RepositoryProvider
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductDescriptionRepository, ProductDescriptionRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICartDescriptions, CartDescriptions>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
    }
}