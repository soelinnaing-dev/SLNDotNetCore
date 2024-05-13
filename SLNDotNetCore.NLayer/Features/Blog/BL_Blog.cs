using SLNDotNetCore.NLayer.Models;

namespace SLNDotNetCore.NLayer.Features.Blog
{
    public class BL_Blog
    {
        readonly DA_Blog _daBlog;

        public BL_Blog()
        {
            _daBlog = new DA_Blog();
        }

        internal List<BlogModel> GetBlogs()
        {
            var lst = _daBlog.GetBlogs();
            return lst;
        }

        internal BlogModel GetBlog(int id)
        {
            var resutl = _daBlog.GetBlog(id);
            return resutl;
        }

        internal int CreateBlog(BlogModel requestModel)
        {           
            var result = _daBlog.CreateBlog(requestModel);
            return result;
        }

        internal int UpdatBlog(int id, BlogModel requestModel)
        {
            var result = _daBlog.UpdatBlog(id, requestModel);
            return result;
        }

        internal int PatchBlog(int id, BlogModel requestModel)
        {
            var result = _daBlog.PatchBlog(id, requestModel);
            return result;
        }

        internal int DeleteBlog(int id)
        {
            var result = _daBlog.DeleteBlog(id);
            return result;
        }
    }
}
