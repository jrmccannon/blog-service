using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository repository;

        public BlogsController(IBlogRepository repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BlogPost>> GetRecentPosts()
        {
            var result = repository.GetRecentPosts();
            
            return result;
        }
    }
}