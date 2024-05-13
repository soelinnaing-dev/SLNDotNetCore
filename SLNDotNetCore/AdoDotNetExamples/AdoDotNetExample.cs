using SLNDotNetCore.ConsoleApp.ConnectionStrings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.ConsoleApp.AdoDotNet
{
    internal class AdoDotNetExample
    {
        ConnectoinStrings constring = new ConnectoinStrings();
        public void RunAdoDotNetExample()
        {
            Console.WriteLine("This is AdoDotNet Example\r\n#############################");
            read();
            Update(1, "Ado Updated Title", "Ado Updated Author", "Ado Updated Content");
            Edit(1);
            Delete(1);
            Create("Ado Create Title", "Ado Create Author", "Ado Create Content");
        }
        public void read()
        {
            SqlConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
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
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine("BlogId => " + row["BlogId"]);
                    Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                    Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                    Console.WriteLine("BlogContent => " + row["BlogContent"]);
                    Console.WriteLine("**************************");
                }
            }
        }
        public void Create(string title, string author, string content)
        {
            SqlConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
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
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@content", content);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            string message = result > 0 ? "New Data Inserted" : "Wrong";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            SqlConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            con.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
            SET [BlogTitle] = @title
            ,[BlogAuthor] = @author
            ,[BlogContent] = @content
            WHERE BlogId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@content", content);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            string message = result > 0 ? "Update Successful" : "Update Fail!";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            con.Open();
            string query = @"Delete From Tbl_Blog
                            Where BlogId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            string message = result > 0 ? "Data row deleted" : "Deleting Fail!";
            Console.WriteLine(message);
        }
        public void Edit(int id)
        {
            SqlConnection con = new SqlConnection(constring._constringbuilder.ConnectionString);
            con.Open();
            string query = @"Select * From Tbl_Blog
                            Where BlogId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (con.State == ConnectionState.Closed && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                Console.WriteLine("BlogId => " + row["BlogId"]);
                Console.WriteLine("BlogTitle => " + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor => " + row["BlogAuthor"]);
                Console.WriteLine("BlogContent => " + row["BlogContent"]);
            }
        }
    }
}
