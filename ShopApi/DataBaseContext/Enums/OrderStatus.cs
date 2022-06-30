namespace ShopApi.DataBaseContext.Enums;

[Flags]
public enum OrderStatus : byte
{
    None = 0,
    InProcess = 1 << 1,
    Processes = 1 << 2,
    Sent = 1 << 3,
    Received = 1 << 4
}