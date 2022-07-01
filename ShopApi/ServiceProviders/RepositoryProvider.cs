namespace ShopApi.ServiceProviders;

public static class RepositoryProvider
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}