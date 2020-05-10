using System;

namespace BlogService
{
    public class BlogPost
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public string Body { get; set; } = String.Empty;
    }
}