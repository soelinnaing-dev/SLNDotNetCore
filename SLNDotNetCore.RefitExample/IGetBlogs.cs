using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.RefitExample
{
    internal interface IGetBlogs
    {
        [Get("/api/EFCoreBlog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/EFCoreBlog/{id}")]
        Task<BlogModel> GetBlog(int id);

        [Post("/api/EFCoreBlog")]
        Task<string> CreateBlog(BlogModel blog);

        [Put("/api/EFCoreBlog/{id}")]
        Task<string> UpdateBlog(int id,BlogModel blog);

        [Delete("/api/EFCoreBlog/{id}")]
        Task<string> DeleteBlog(int id);
    }

    public class BlogModel
    {
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
}
