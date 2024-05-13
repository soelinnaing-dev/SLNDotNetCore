using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using SLNDotNetCore.WebAPI.Models;

namespace SLNDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoBlogController : ControllerBase
    {
        SqlConnection con = new SqlConnection(ConnectionStrings.ConnectoinStrings._constringbuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlog()
        {
            con.Open();
            string query = @"SELECT [BlogId]
                            ,[BlogTitle]
                            ,[BlogAuthor]
                            ,[BlogContent]
                            FROM [dbo].[Tbl_Blog]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            //List<BlogModel> lst = new List<BlogModel>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel();
            //    blog.BlogId = Convert.ToInt32(row["BlogId"]);
            //    blog.BlogTitle = Convert.ToString(row["BlogTitle"]);
            //    blog.BlogAuthor = Convert.ToString(row["BlogAuthor"]);
            //    blog.BlogContent = Convert.ToString(row["BlogContent"]);
            //    lst.Add(blog);
            //}
            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();
            return Ok(lst);
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
            con.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
            VALUES
           (@title,
           @author,
          @content)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@title", model.BlogTitle);
            cmd.Parameters.AddWithValue("@author", model.BlogAuthor);
            cmd.Parameters.AddWithValue("@content", model.BlogContent);
            int result = cmd.ExecuteNonQuery();
            con.Close();
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
            con.Open();
            if (string.IsNullOrEmpty(model.BlogTitle) || string.IsNullOrEmpty(model.BlogAuthor) || string.IsNullOrEmpty(model.BlogContent))
            {
                return NotFound("Data must not be empty");
            }
            string query = @"UPDATE [dbo].[Tbl_Blog]
            SET [BlogTitle] = @title
            ,[BlogAuthor] = @author
            ,[BlogContent] = @content
            WHERE BlogId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            
                cmd.Parameters.AddWithValue("@id", id);
            
                cmd.Parameters.AddWithValue("@title", model.BlogTitle);
            
            
                cmd.Parameters.AddWithValue("@author", model.BlogAuthor);
            
                cmd.Parameters.AddWithValue("@content", model.BlogContent);
            
            int result = cmd.ExecuteNonQuery();
            con.Close();
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
            string condition = string.Empty;
            if(!string.IsNullOrEmpty(model.BlogTitle))
            {
                condition += "[BlogTitle] = @title, ";
            }
            if(!string.IsNullOrEmpty(model.BlogAuthor))
            {
                condition += "[BlogAuthor] = @author, ";
            }
            if(!string.IsNullOrEmpty (model.BlogContent))
            {
                condition += "[BlogContent] = @content, ";
            }
            condition = condition.Substring(0, condition.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET {condition}
            WHERE BlogId = @id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            
            if(!string.IsNullOrEmpty(model.BlogTitle) )
            {
                cmd.Parameters.AddWithValue("@title", model.BlogTitle);
            }
            if(!string.IsNullOrEmpty(model.BlogAuthor) )
            {
                cmd.Parameters.AddWithValue("@author", model.BlogAuthor);
            }
            if(!string.IsNullOrEmpty(model.BlogContent))
            {
                cmd.Parameters.AddWithValue("@content", model.BlogContent);
            }          
            int result = cmd.ExecuteNonQuery();
            con.Close();
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
            con.Open();
            string query = @"Delete From Tbl_Blog
                            Where BlogId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            string message = result > 0 ? "Data row deleted" : "Deleting Fail!";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            con.Open();
            string query = @"Select * From Tbl_Blog
                            Where BlogId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if(dt.Rows.Count==0)
            {
                return null;
            }
            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };
            return item;
        }
    }
}
