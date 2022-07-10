namespace ShopApi.DataBaseContext.Repositories.Role;

public interface IRoleRepository : ICRUD_REpository<Entities.Role>
{
    public Task<Entities.Role> GetRoleBySysName(byte sysName);
}