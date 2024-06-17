using Microsoft.EntityFrameworkCore;
using SLNDotNetCore.NLayer.DataAccess.DB;
using SLNDotNetCore.NLayer.DataAccess.Models;

namespace SLNDotNetCore.NLayer.DataAccess.Services
{
    public class DA_Blog
    {
        private readonly AppDbContex _appdb;
        public DA_Blog()
        {
            _appdb = new AppDbContex();
        }

        public List<BlogModel> GetBlogs()//DataAccess
        {
            var lst = _appdb.Blogs.ToList();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var result = _appdb.Blogs.FirstOrDefault(x => x.BlogId == id);
            return result;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            _appdb.Add(requestModel);
            var result = _appdb.SaveChanges();
            return result;
        }

        public int UpdatBlog(int id, BlogModel requestModel)
        {
            var item = _appdb.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
                return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _appdb.SaveChanges();
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var item = _appdb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
                return 0;

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                item.BlogTitle = requestModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                item.BlogContent = requestModel.BlogContent;
            }

            var result = _appdb.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _appdb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _appdb.Blogs.Remove(item);
            var result = _appdb.SaveChanges();
            return result;
        }
    }
}
