namespace ShopApi.DataBaseContext.Repositories.Role;

public sealed class RoleRepository : CRUD_Repository<Entities.Role>, IRoleRepository
{
    public RoleRepository(DataBaseContext context) : base(context)
    {
    }
}