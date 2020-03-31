using System;
using System.IO;
using System.Linq;

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
                    if (String.IsNullOrEmpty(result.AuthorName))
                    {
                        result.AuthorName = GetAuthorName(line);
                    }
                    else if (String.IsNullOrEmpty(result.Title))
                    {
                        result.Title = GetTitle(line);
                    }
                    else if (result.PostDate == DateTime.MinValue)
                    {
                        result.PostDate = GetPostDate(line);
                    }
                    else if (line.StartsWith("@end"))
                    {
                        metadataDone = true;
                    }
                    else if (metadataDone)
                    {
                        result.Body = string.Concat(result.Body, line);
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

            if (DateTime.TryParse(value, out DateTime date))
            {
                return date;
            }

            return DateTime.MinValue;
        }
    }
}