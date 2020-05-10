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
                bool metadataDone = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (String.IsNullOrEmpty(result.AuthorName) && line.StartsWith("@author"))
                    {
                        result.AuthorName = GetAuthorName(line);
                    }
                    else if (String.IsNullOrEmpty(result.Title) && line.StartsWith("@title"))
                    {
                        result.Title = GetTitle(line);
                    }
                    else if (result.PostDate == DateTime.MinValue && line.StartsWith("@post-date"))
                    {
                        result.PostDate = GetPostDate(line);
                    }
                    else if (line.StartsWith("@end"))
                    {
                        metadataDone = true;
                    }
                    else if (metadataDone)
                    {
                        result.Body = string.Concat(result.Body, "\n", line);
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
            return line.StartsWith($"@{fieldName}") ? line.Substring(line.IndexOf('=') + 1) : string.Empty;
        }

        private DateTime GetPostDate(string line)
        {
            var value = ParseField("post-date", line);

            return DateTime.TryParse(value, out DateTime date) ? date : DateTime.MinValue;
        }
    }
}