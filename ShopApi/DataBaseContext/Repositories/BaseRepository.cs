namespace ShopApi.DataBaseContext.Repositories;

public abstract class BaseRepository
{
    protected readonly DataBaseContext Context;

    protected BaseRepository(DataBaseContext context)
    {
        Context = context;
    }
    
    
}