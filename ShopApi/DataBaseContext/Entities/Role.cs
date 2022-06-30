namespace ShopApi.DataBaseContext.Entities;

public sealed class Role : BaseEntity
{
    public string Name { get; set; }
    public byte SysName { get; set; }

    public ICollection<User> Users { get; set; }
}