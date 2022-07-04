namespace ShopApi.DataBaseContext.Repositories.CRUD;

public interface ICRUD_REpository<T> where T : BaseEntity
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(Guid id);
    public Task<T> Add(T? entity);
    public Task<T> Update(T entity);
    public Task<T> Remove(Guid id);
}