using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SLNDotNetCore.ConsoleApp.ConnectionStrings;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using SLNDotNetCore.ConsoleApp.Models;

namespace SLNDotNetCore.ConsoleApp.Dapper
{
    internal class DapperExample
    {
        ConnectoinStrings constring = new ConnectoinStrings();
        public void run()
        {
            Console.WriteLine("This is Dapper Example\r\n########################");
            Read();
            Edit(2);
            Update(2, "Update Title", "Update Author", "Update Content");
            Delete(2);
            Create("Dapper Create Title", "Dapper Create Author", "Dapper Create Content");

        }
        private void Read()
        {
            using IDbConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            List<BlogDto> lst = con.Query<BlogDto>("select * from Tbl_Blog").ToList();
            foreach (BlogDto blog in lst)
            {
                Console.WriteLine("BlogId is => " + blog.BlogId);
                Console.WriteLine("BlogTitle is => " + blog.BlogTitle);
                Console.WriteLine("BlogAuthor is => " + blog.BlogAuthor);
                Console.WriteLine("BlogContent is => " + blog.BlogContent + "\r\n*******************");
            }
        }
        private void Edit(int id)
        {
            using IDbConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            var item = con.Query<BlogDto>("select * from Tbl_Blog where BlogId=@BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            string message = item is null ? "Item Not Found" : $"Searched Item is {item.BlogId}\r\n{item.BlogTitle}\r\n{item.BlogAuthor}\r\n{item.BlogContent}";
            Console.WriteLine(message);
        }
        private void Update(int id, string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"
        UPDATE [dbo].[Tbl_Blog]
        SET [BlogTitle] = @BlogTitle,
            [BlogAuthor] = @BlogAuthor,
            [BlogContent] = @BlogContent
        WHERE BlogId = @BlogId";
            using IDbConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            int result = con.Execute(query, item);

            string message = result > 0 ? "Update Successful" : "Update Failed";
            Console.WriteLine(message + "\r\n");
        }
        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using IDbConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            int result = con.Execute(query, item);
            string message = result > 0 ? "Creating Successful!" : "Creating Failed!";
            Console.WriteLine(message + "\r\n");
        }
        private void Delete(int id)
        {
            var item = new BlogDto { BlogId = id };
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            using IDbConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            int result = con.Execute(query, item);
            string message = result > 0 ? "Delete Successfully!" : "Delete Failed!";
            Console.WriteLine(message + "\r\n");

        }
    }
}
