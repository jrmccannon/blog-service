using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogService
{
    public interface IBlogRepository
    {
        Task<BlogPost> GetPost(Guid id);
        IEnumerable<BlogPost> GetRecentPosts();
        Task<IEnumerable<BlogPost>> GetPosts(int take, int skip);
    }
}