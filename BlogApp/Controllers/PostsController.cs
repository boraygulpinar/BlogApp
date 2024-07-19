using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View(
                new PostWithTagViewModel
                {
                    Posts = _postRepository.Posts.ToList()
                }
                );
        }
    }
}
