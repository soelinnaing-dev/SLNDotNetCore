using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using SLNDotNetCore.WebAPI.ConnectionStrings;
using System.Data.SqlClient;
using SLNDotNetCore.WebAPI.Models;
using SLNDotNetCore.Shared;

namespace SLNDotNetCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperBlog2Controller : ControllerBase
    {
        DapperService _dapperService = new DapperService(ConnectoinStrings._constringbuilder.ConnectionString);
        [HttpGet]
        public IActionResult Read()
        {
            string query = "Select * From Tbl_Blog";
            using IDbConnection dbCon = new SqlConnection(ConnectoinStrings._constringbuilder.ConnectionString);
            //var list = dbCon.Query<BlogModel>(query).ToList();
            var list = _dapperService.Query<BlogModel>(query,null);
            return Ok(list);

        }
        [HttpGet("{id}")]
        public IActionResult ReadWithId(int id)
        {
            var item = FindById(id);
            if(item is null)
            {
                return NotFound("Item Not Found!");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(BlogModel model)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            //using IDbConnection dbCon = new SqlConnection(ConnectoinStrings._constringbuilder.ConnectionString);
            //int result = dbCon.Execute(query,model);
            int result = _dapperService.Execute(query, model);
            string message = result > 0 ? "Create Successful!" : "Create Failed!";
            return Ok(message);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,BlogModel model)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("Not Found!");
            }
            model.BlogId = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            //using IDbConnection dbCon = new SqlConnection(ConnectoinStrings._constringbuilder.ConnectionString);
            //int result = dbCon.Execute(query, model);
            int result = _dapperService.Execute(query, model);
            string message = result > 0 ? "Update Successful" : "Update Failed!";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel model)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found!");
            }
            model.BlogId = id;
            string condition = string.Empty;
            if (!string.IsNullOrEmpty(model.BlogTitle))
            {
                condition += "[BlogTitle] = @BlogTitle, ";
            }
            if(!string.IsNullOrEmpty(model.BlogAuthor))
            {
                condition += "[BlogAuthor] = @BlogAuthor, ";
            }
            if(!string.IsNullOrEmpty(model.BlogContent))
            {
                condition += "[BlogContent] = @BlogContent, ";
            }
            if (condition.Length == 0)
                return NotFound("Invalid input!");
            condition = condition.Substring(0, condition.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition}
 WHERE BlogId = @BlogId";

            //using IDbConnection dbCon = new SqlConnection(ConnectoinStrings._constringbuilder.ConnectionString);
            //int result = dbCon.Execute(query,model);
            int result = _dapperService.Execute(query, model);

            string message = result > 0 ? "Update Successful" : "Update Failed!";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var check = FindById(id);
            if(check is null)
            {
                return NotFound("No Data Found!");
            }
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            //using IDbConnection dbCon = new SqlConnection(ConnectoinStrings._constringbuilder.ConnectionString);
            //dbCon.Execute(query, new BlogModel { BlogId = id });
            int result = _dapperService.Execute(query, new BlogModel { BlogId = id });
            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            return Ok(message);
        }

        private BlogModel? FindById(int id)
        {
            string query1 = "Select * from Tbl_Blog Where BlogId = @BlogId";
            //using IDbConnection dbCon = new SqlConnection(ConnectoinStrings._constringbuilder.ConnectionString);
            //var result = dbCon.Query<BlogModel>(query1, new BlogModel { BlogId = id }).FirstOrDefault();
            var result = _dapperService.QueryFirstOrDefault<BlogModel>(query1, new BlogModel { BlogId = id });
            return result;
        }
    }
}
