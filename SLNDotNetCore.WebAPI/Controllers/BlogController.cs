using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using SLNDotNetCore.WebAPI.Models;

namespace SLNDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFCoreBlogController : ControllerBase
    {
        AppDbContex appdb = new AppDbContex();
        
        [HttpGet]
        public IActionResult Read()
        {
            var result = appdb.Blogs.ToList();
            return Ok(result);          
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var result = appdb.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if (result == null)
            {
                return NotFound("No Item Found!");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            appdb.Blogs.Add(blog);
            var result = appdb.SaveChanges();
            string message = result > 0 ? "Create Successful" : "Create Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,BlogModel blog)
        {
            var item = appdb.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if(item == null)
            {
                return NotFound("The item that you want update id not found!");
            }
            string errorMessage;
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
               item.BlogTitle = blog.BlogTitle;
            }
            else
            {
                errorMessage = "BlogTitle is empty";
                return Ok(errorMessage);
            }
            if(!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            else
            {
                errorMessage = "BlogAuthor is empty";
                return Ok(errorMessage);
            }
            if(!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            else
            {
                errorMessage = "BlogContent is empty";
                return Ok(errorMessage);
            }
            var result = appdb.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Update Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = appdb.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if(item == null)
            {
                return NotFound("Item Not Found!");
            }
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle=blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if(!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent=blog.BlogContent;
            }
            var result = appdb.SaveChanges();
            string message = result > 0 ? "Patch Successful" : "Patch failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = appdb.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if(item == null)
            {
                return NotFound("Your searched item not found!");
            }
            appdb.Remove(item);
            var result = appdb.SaveChanges();
            string message = result>0 ? "Delete successful" : "Delete Failed";
            return Ok(message);
        }
    }
}
