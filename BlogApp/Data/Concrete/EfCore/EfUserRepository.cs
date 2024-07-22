using BlogApp.Data.Abstract;
using BlogApp.Entitiy;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfUserRepository : IUserRepository
    {
        private BlogContext _blogContext;

        public EfUserRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IQueryable<User> Users => _blogContext.Users;

        public void CreateUser(User user)
        {
            _blogContext.Users.Add(user);
            _blogContext.SaveChanges();
        }
    }
}
