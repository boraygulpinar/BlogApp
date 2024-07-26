using BlogApp.Data.Abstract;
using BlogApp.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository
    {
        private BlogContext _context;

        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }

        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        void IPostRepository.EditPost(Post post)
        {
            var entity = _context.Posts.FirstOrDefault(i => i.PostID == post.PostID);
            if (entity != null)
            {
                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.Content = post.Content;
                entity.URL = post.URL;
                entity.IsActive = post.IsActive;

                _context.SaveChanges();
            }
        }

        void IPostRepository.EditPost(Post post, int[] tagIds)
        {
            var entity = _context.Posts.Include(i => i.Tags).FirstOrDefault(i => i.PostID == post.PostID);
            if (entity != null)
            {
                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.Content = post.Content;
                entity.URL = post.URL;
                entity.IsActive = post.IsActive;

                entity.Tags = _context.Tags.Where(tag => tagIds.Contains(tag.TagID)).ToList();

                _context.SaveChanges();
            }
        }
    }
}
