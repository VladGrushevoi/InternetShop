namespace ShopApi.DataBaseContext.Repositories.User;

public sealed class UserRepository : CRUD_Repository<Entities.User>, IUserRepository
{
    public UserRepository(DataBaseContext context) : base(context)
    {
        
    }
}