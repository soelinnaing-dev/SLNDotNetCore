using SLNDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.ConsoleApp.EFCore
{
    internal class EFCoreExample
    {
        AppDbContex AppDbContex = new AppDbContex();
        public void run()
        {
            Console.WriteLine("EFCore Example\r\n####################");
            Read();
            Edit(3);
            Update(3, "EFCore Update Title", "EFCore Update Author", "EFCore Update Content");
            Create("EFCore Create Title", "EFCore Create Author", "EFCore Create Content");
            Delete(3);

            Console.WriteLine("EFCore Example Finished\r\n");
        }
        private void Read()
        {
            var list = AppDbContex.Blogs.ToList();
            foreach (var item in list)
            {
                Console.WriteLine("BlogId is => " + item.BlogId);
                Console.WriteLine("BlogTitle is => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor is => " + item.BlogAuthor);
                Console.WriteLine("BlogContent is => " + item.BlogContent + "\r\n*******************");
            }
        }
        private void Edit(int id)
        {
            var item = AppDbContex.Blogs.FirstOrDefault(x => x.BlogId == id);
            string message = item is null ? "Item Not Found" : $"Searched Item is {item.BlogId}\r\n{item.BlogTitle}\r\n{item.BlogAuthor}\r\n{item.BlogContent}";
            Console.WriteLine(message + "\r\n");
        }
        private void Update(int id, string title, string author, string content)
        {
            var item = AppDbContex.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            }
            item.BlogId = id; item.BlogTitle = title; item.BlogAuthor = author; item.BlogContent = content;
            int result = AppDbContex.SaveChanges();
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
            AppDbContex.Add(item);
            int result = AppDbContex.SaveChanges();
            string message = result > 0 ? "Creating Successful!" : "Creating Failed!";
            Console.WriteLine(message + "\r\n");
        }
        private void Delete(int id)
        {
            var item = AppDbContex.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            }
            AppDbContex.Remove(item);
            int result = AppDbContex.SaveChanges();
            string message = result>0? "Delete Successfully!": "Delete Failed!";
            Console.WriteLine(message+"\r\n");
        }
    }
}
