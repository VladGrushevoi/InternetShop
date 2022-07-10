namespace ShopApi.DataBaseContext.Repositories.Product;

public sealed class ProductRepository : CRUD_Repository<Entities.Product>, IProductRepository
{
    public ProductRepository(DataBaseContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Entities.Product>> GetAll()
    {
        var result = await Context.Products!.Include(c => c.Category)
            .Include(p => p.ProductDescription).ToListAsync();

        return result;
    }

    public override async Task<Entities.Product> Remove(Guid id)
    {
        var result = await Context.Products!.Where(p => p.Id == id)
            .Include(c => c.ProductDescription)
            .FirstOrDefaultAsync();

        var removeEnt =  Context.Products!.Remove(result!);
        Context.ProductDescriptions!.Remove(result!.ProductDescription);
        await Context.SaveChangesAsync();

        return removeEnt.Entity;
    }
}