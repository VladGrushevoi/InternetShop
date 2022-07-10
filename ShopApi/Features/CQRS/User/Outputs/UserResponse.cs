using ShopApi.Features.CQRS.Role.Outputs;

namespace ShopApi.Features.CQRS.User.Outputs;

public class UserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }

    public RoleResponse? Role { get; set; }
    
    public UserResponse() {}

    public UserResponse(DataBaseContext.Entities.User entity)
    {
        Id = entity.Id;
        FirstName = entity.FirstName;
        SecondName = entity.SecondName;
        Login = entity.Login;
        Password = entity.Password;
        Phone = entity.Phone;
        Role = entity.Role is not null ? new RoleResponse(entity.Role) : null;

    }
}