namespace ShopApi.DataBaseContext.Repositories.Comment;

public sealed class CommentRepository : CRUD_Repository<Entities.Comment>, ICommentRepository
{
    public CommentRepository(DataBaseContext context) : base(context)
    {
    }
}