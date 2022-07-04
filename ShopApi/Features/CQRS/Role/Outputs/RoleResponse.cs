namespace ShopApi.Features.CQRS.Role.Outputs;

public sealed class RoleResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte SysName { get; set; }

    public RoleResponse(){}
    public RoleResponse(DataBaseContext.Entities.Role role)
    {
        Id = role.Id;
        Name = role.Name;
        SysName = role.SysName;
    }
}