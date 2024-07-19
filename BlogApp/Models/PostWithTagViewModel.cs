using BlogApp.Entitiy;

namespace BlogApp.Models
{
    public class PostWithTagViewModel
    {
        public List<Post> Posts { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
    }
}
