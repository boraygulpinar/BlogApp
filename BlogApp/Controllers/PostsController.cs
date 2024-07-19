using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;

        public PostsController(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            return View(
                new PostWithTagViewModel
                {
                    Posts = _postRepository.Posts.ToList(),
                    Tags = _tagRepository.Tags.ToList()
                }
                );
        }
    }
}
