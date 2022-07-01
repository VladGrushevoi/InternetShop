namespace ShopApi.DataBaseContext.Repositories.CRUD;

public class CRUD_Repository<T> : BaseRepository, ICRUD_REpository<T> where T : BaseEntity
{
    protected CRUD_Repository(DataBaseContext context) : base(context)
    {
        
    }
    
    public async Task<IEnumerable<T>> GetAll()
    {
        var result = Context.Set<T>().ToListAsync();

        return await result;
    }

    public async Task<T> GetById(Guid id)
    {
        var result = await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        if (result is null) throw new NullReferenceException();

        return result;
    }

    public async Task<T> Add(T? entity)
    {
        if (entity is null) throw new NullReferenceException();
        var result = Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();

        return result.Result.Entity;
    }

    public async Task<T> Update(T entity)
    {
        var result = Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<T> Remove(T entity)
    {
        var result = Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();

        return result.Entity;
    }
}