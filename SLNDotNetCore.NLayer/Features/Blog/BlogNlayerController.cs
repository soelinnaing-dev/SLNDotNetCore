using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLNDotNetCore.NLayer.Models;

namespace SLNDotNetCore.NLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogNlayerController : ControllerBase
    {
        private readonly BL_Blog _blBlog;
        public BlogNlayerController()
        {
            _blBlog = new BL_Blog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var result = _blBlog.GetBlogs();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var result = _blBlog.GetBlog(id);
            if (result == null)
            {
                return NotFound("No Item Found!");
            }
            return Ok(result);

        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _blBlog.CreateBlog(blog);
            string message = result > 0 ? "Create Successful" : "Create Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var result = _blBlog.UpdatBlog(id, blog);
            string message = result > 0 ? "Update Successful" : "Update Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var result = _blBlog.PatchBlog(id, blog);
            string message = result > 0 ? "Patch Successful" : "Patch failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _blBlog.DeleteBlog(id);
            string message = result > 0 ? "Delete successful" : "Delete Failed";
            return Ok(message);
        }
    }
}
