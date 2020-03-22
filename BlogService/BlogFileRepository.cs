using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService
{
    public class BlogFileRepository : IBlogRepository
    {
        private static readonly string PostsDirectory = Path.Combine("Posts");
        
        public Task<BlogPost> GetPost(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPost> GetRecentPosts()
        {
            var directory = new DirectoryInfo(PostsDirectory);

            var files = directory
                                            .GetFiles()
                                            .OrderByDescending(f => f.CreationTimeUtc)
                                            .Take(5);
            
            return new List<BlogPost>();
        }

        public Task<IEnumerable<BlogPost>> GetPosts(int take, int skip)
        {
            throw new NotImplementedException();
        }
    }
}