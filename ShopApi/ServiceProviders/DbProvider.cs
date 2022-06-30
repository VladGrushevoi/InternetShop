namespace ShopApi.ServiceProviders;

public static class DbProvider
{
    public static void AddDataBaseService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataBaseContext.DataBaseContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("Shop") ?? throw new InvalidOperationException()));
    }
}