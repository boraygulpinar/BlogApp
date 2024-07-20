﻿namespace BlogApp.Entitiy
{
    public class Tag
    {
        public int TagID { get; set; }
        public string? Text { get; set; }
        public string? URL { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
