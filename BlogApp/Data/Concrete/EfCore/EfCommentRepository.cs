using BlogApp.Data.Abstract;
using BlogApp.Entitiy;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfCommentRepository : ICommentRepository
    {
        private BlogContext _blogContext;

        public EfCommentRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IQueryable<Comment> Comments => _blogContext.Comments;

        public void CreateComment(Comment comment)
        {
            _blogContext.Comments.Add(comment);
            _blogContext.SaveChanges();
        }
    }
}
