using SLNDotNetCore.NLayer.DataAccess.Services;
using SLNDotNetCore.NLayer.DataAccess.Models;

namespace SLNDotNetCore.NLayer.BusinessLogic.Services
{
    public class BL_Blog
    {
        readonly DA_Blog _daBlog;

        public BL_Blog()
        {
            _daBlog = new DA_Blog();
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _daBlog.GetBlogs();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var resutl = _daBlog.GetBlog(id);
            return resutl;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            var result = _daBlog.CreateBlog(requestModel);
            return result;
        }

        public int UpdatBlog(int id, BlogModel requestModel)
        {
            var result = _daBlog.UpdatBlog(id, requestModel);
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var result = _daBlog.PatchBlog(id, requestModel);
            return result;
        }

        public int DeleteBlog(int id)
        {
            var result = _daBlog.DeleteBlog(id);
            return result;
        }
    }
}
