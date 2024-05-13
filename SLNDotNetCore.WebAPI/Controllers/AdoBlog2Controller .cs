using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using SLNDotNetCore.WebAPI.Models;
using SLNDotNetCore.Shared;

namespace SLNDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoBlog2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService= new AdoDotNetService(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);
        SqlConnection con = new SqlConnection(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = @"SELECT [BlogId]
                            ,[BlogTitle]
                            ,[BlogAuthor]
                            ,[BlogContent]
                            FROM [dbo].[Tbl_Blog]";
            
            
            var list = _adoDotNetService.Query<BlogModel>(query);
            return Ok(list);
        }
            
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Blogcreate(BlogModel model)
        {
            
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
            VALUES
           (@title,
           @author,
          @content)";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@title", model.BlogTitle);
            //cmd.Parameters.AddWithValue("@author", model.BlogAuthor);
            //cmd.Parameters.AddWithValue("@content", model.BlogContent);
            //int result = cmd.ExecuteNonQuery();
            //con.Close();
            var result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@title", model.BlogTitle!), new AdoDotNetParameter("@author", model.BlogAuthor!),
                new AdoDotNetParameter("@content", model.BlogContent!));
            string message = result > 0 ? "Create Successful" : "Create Failed";
            return Ok(message);
        }
        [HttpPut]
        public IActionResult Update(int id, [FromBody]BlogModel model)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found!");
            }         
            if (string.IsNullOrEmpty(model.BlogTitle) || string.IsNullOrEmpty(model.BlogAuthor) || string.IsNullOrEmpty(model.BlogContent))
            {
                return NotFound("Data must not be empty");
            }
            string query = @"UPDATE [dbo].[Tbl_Blog]
            SET [BlogTitle] = @title
            ,[BlogAuthor] = @author
            ,[BlogContent] = @content
            WHERE BlogId = @id";
            //SqlCommand cmd = new SqlCommand(query, con);

            //    cmd.Parameters.AddWithValue("@id", id);

            //    cmd.Parameters.AddWithValue("@title", model.BlogTitle);


            //    cmd.Parameters.AddWithValue("@author", model.BlogAuthor);

            //    cmd.Parameters.AddWithValue("@content", model.BlogContent);

            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@id", id), new AdoDotNetParameter("@title", model.BlogTitle),
                new AdoDotNetParameter("@author", model.BlogAuthor), new AdoDotNetParameter("@content", model.BlogContent));
            string message = result > 0 ? "Update Successful" : "Update Failed";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateById(int id, BlogModel model)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found");
            }
            string query = @"UPDATE [dbo].[Tbl_Blog]
            SET [BlogTitle] = @title
            ,[BlogAuthor] = @author
            ,[BlogContent] = @content
            WHERE BlogId = @id";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@id", id);
            //if (!string.IsNullOrEmpty(model.BlogTitle))
            //{
            //    cmd.Parameters.AddWithValue("@title", model.BlogTitle);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@title", item.BlogTitle);
            //}
            //if (!string.IsNullOrEmpty(model.BlogAuthor))
            //{
            //    cmd.Parameters.AddWithValue("@author", model.BlogAuthor);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@author", item.BlogAuthor);
            //}
            //if (!string.IsNullOrEmpty(model.BlogContent))
            //{
            //    cmd.Parameters.AddWithValue("@content", model.BlogContent);
            //}
            //else
            //{
            //    cmd.Parameters.AddWithValue("@content", item.BlogContent);
            //}
            AdoDotNetParameter[] para = new AdoDotNetParameter[4];
            {
                para[0] = new AdoDotNetParameter("@id", id);
                if(!string.IsNullOrEmpty(model.BlogTitle))
                {
                    para[1] = new AdoDotNetParameter("@title", model.BlogTitle);
                }
                else
                {
                    para[1] = new AdoDotNetParameter("@title", item.BlogTitle!);
                }
                if(!string.IsNullOrEmpty(model.BlogAuthor))
                {
                    para[2] = new AdoDotNetParameter("@author", model.BlogAuthor);
                }
                else
                {
                    para[2] = new AdoDotNetParameter("@author", item.BlogAuthor!);
                }
                if(!string.IsNullOrEmpty(model.BlogContent))
                {
                    para[3] = new AdoDotNetParameter("@content",model.BlogContent);
                }
                else
                {
                    para[3]=new AdoDotNetParameter("@content",item.BlogContent!);
                }
            };

            int result = _adoDotNetService.Execute(query, para);         
            string message = result > 0 ? "Update Successful!" : "Update Failed";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("No Data Found!");
            }
            string query = @"Delete From Tbl_Blog
                            Where BlogId = @id";
            int result = _adoDotNetService.Execute(query,new AdoDotNetParameter("@id",id));
            string message = result > 0 ? "Data row deleted" : "Deleting Fail!";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            con.Open();
            string query = @"Select * From Tbl_Blog
                            Where BlogId = @id";
            AdoDotNetParameter[] para = new AdoDotNetParameter[1];
            para[0] = new AdoDotNetParameter("@id", id);
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, para);
            return item;
        }
    }
}
