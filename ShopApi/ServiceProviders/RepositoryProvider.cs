using ShopApi.DataBaseContext.Repositories.Category;

namespace ShopApi.ServiceProviders;

public static class RepositoryProvider
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}