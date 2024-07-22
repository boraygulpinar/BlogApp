using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using BlogApp.Entitiy;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;

        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRepository.Posts;
            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.URL == tag));
            }

            return View(new PostWithTagViewModel { Posts = await posts.ToListAsync() });
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository
                .Posts
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(p => p.URL == url));
        }

        public JsonResult AddComment(int PostID, string UserName, string CommentText)
        {
            var entity = new Comment
            {
                CommentText = CommentText,
                PublishedOn = DateTime.Now,
                PostID = PostID,
                User = new User { UserName = UserName, Image = "avatar.jpg" }                
            };
            _commentRepository.CreateComment(entity);

            return Json(new
            {
                UserName,
                CommentText,
                entity.PublishedOn,
                entity.User.Image
            });
        }
    }
}
