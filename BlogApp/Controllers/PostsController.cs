using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
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
            return View(await _postRepository.Posts.FirstOrDefaultAsync(p => p.URL == url));
        }
    }
}
