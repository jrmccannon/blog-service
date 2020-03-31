using System;
using System.IO;

namespace BlogService
{
    public class FileInfoTransformer
    {
        public BlogPost TransformToBlogPost(FileInfo file)
        {
            var result = new BlogPost();
            
            using (var reader = file.OpenText())
            {
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    if (String.IsNullOrEmpty(result.AuthorName))
                    {
                        result.AuthorName = GetAuthorName(line);
                    }
                    
                    if (String.IsNullOrEmpty(result.Title))
                    {
                        result.Title = GetTitle(line);
                    }
                }
            }

            return result;
        }

        private string GetAuthorName(string line)
        {
            return ParseField("author", line);
        }
        
        private string GetTitle(string line)
        {
            return ParseField("title", line);
        }

        private string ParseField(string fieldName, string line)
        {
            return line.StartsWith($"@{fieldName}") ? line.Substring(line.IndexOf('=')+1) : string.Empty;
        }
    }
}