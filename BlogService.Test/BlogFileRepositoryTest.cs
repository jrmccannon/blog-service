using NUnit.Framework;

namespace BlogService.Test
{
    public class BlogFileRepositoryTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetRecentPosts()
        {
            var repository = new BlogFileRepository();

            var posts = repository.GetRecentPosts();
            
            
        }
    }
}