using System.IO;

namespace BlogService
{
    public class FileInfoTransformer
    {
        public BlogPost TransformToBlogPost(FileInfo file)
        {
            return new BlogPost();
        }
    }
}