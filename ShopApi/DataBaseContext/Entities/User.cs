namespace ShopApi.DataBaseContext.Entities;

public sealed class User : BaseEntity
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }

    public Role Role { get; set; }
    public ICollection<Comment>? Coments { get; set; }
    public ICollection<Order>? Orders { get; set; }
}