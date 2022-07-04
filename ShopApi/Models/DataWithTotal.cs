namespace ShopApi.Models;

public class DataWithTotal<T> where T : class
{
    public IEnumerable<T> Items { get; set; }
    public int Total { get; set; }

    public DataWithTotal(IEnumerable<T> data)
    {
        Items = data;
        Total = data.Count();
    }
}