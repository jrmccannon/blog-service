using System.IO;
using System.Linq.Expressions;
using NUnit.Framework;

namespace BlogService.Test
{
    public class FileInfoTransformerTest
    {
        [Test]
        public void Transform_GivenFileInfo_ReturnsPopulatedBlogPost()
        {
            var fileInfo = new FileInfo("");
            
            var transformer = new FileInfoTransformer();

            var blogPost = transformer.TransformToBlogPost(fileInfo);
        }
    }
}