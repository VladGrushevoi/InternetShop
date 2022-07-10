namespace ShopApi.DataBaseContext.Repositories.User;

public sealed class UserRepository : CRUD_Repository<Entities.User>, IUserRepository
{
    public UserRepository(DataBaseContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<Entities.User>> GetAll()
    {
        var entities = await Context.Users!.Include(c => c.Role).ToListAsync();

        return entities;
    }

    public override async Task<Entities.User> GetById(Guid id)
    {
        var entity = await Context.Users!.Where(u => u.Id == id)
            .Include(c => c.Role).FirstOrDefaultAsync();

        return entity!;
    }
}