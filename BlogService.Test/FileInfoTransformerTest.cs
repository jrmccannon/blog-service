using System.IO;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using NUnit.Framework;

namespace BlogService.Test
{
    public class FileInfoTransformerTest
    {
        private static readonly string PostsDirectory = Path.Combine("Posts");
        
        [Test]
        public void Transform_GivenFileInfo_ReturnsPopulatedBlogPost()
        {
            var fileInfo = new DirectoryInfo(PostsDirectory).GetFiles("TEST_file1.md").First();
            
            var blogPost = new FileInfoTransformer().TransformToBlogPost(fileInfo);

            blogPost.AuthorName.Should().Be("Jared McCannon");
            blogPost.Title.Should().Be("Test 1");
        }
    }
}