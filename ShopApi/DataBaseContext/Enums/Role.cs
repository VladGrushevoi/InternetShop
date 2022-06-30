namespace ShopApi.DataBaseContext.Enums;

[Flags]
public enum Role : byte
{
    None = 0,
    Admin = 1 << 1,
    User = 1 << 2,
    Anonymous = 1 << 3
}