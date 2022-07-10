namespace ShopApi.DataBaseContext.Repositories.Role;

public sealed class RoleRepository : CRUD_Repository<Entities.Role>, IRoleRepository
{
    public RoleRepository(DataBaseContext context) : base(context)
    {
    }

    public async Task<Entities.Role> GetRoleBySysName(byte sysName)
    {
        var result = await Context.Roles!.Where(r => r.SysName == sysName).FirstOrDefaultAsync();

        return result!;
    }
}