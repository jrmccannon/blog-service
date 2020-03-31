using System;
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
            var postDate = new DateTime(2020, 1, 1, 7, 0, 0);
            var testContent = "Test content";
            
            var fileInfo = new DirectoryInfo(PostsDirectory).GetFiles("TEST_file1.md").First();
            
            var blogPost = new FileInfoTransformer().TransformToBlogPost(fileInfo);

            blogPost.AuthorName.Should().Be("Jared McCannon");
            blogPost.Title.Should().Be("Test 1");
            blogPost.PostDate.Should().Be(postDate);
            blogPost.Body.Should().Be(testContent);
        }
        
        [Test]
        public void Transform_GivenFileInfo_ReturnsPopulatedBlogPostWithMultipleLines()
        {
            var postDate = new DateTime(2020, 1, 1, 7, 0, 0);
            var testContent = "Test content";
            
            var fileInfo = new DirectoryInfo(PostsDirectory).GetFiles("TEST_file2.md").First();
            
            var blogPost = new FileInfoTransformer().TransformToBlogPost(fileInfo);

            blogPost.Body.Should().Be(testContent);
        }
    }
}