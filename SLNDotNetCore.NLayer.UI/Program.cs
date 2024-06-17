using SLNDotNetCore.NLayer.BusinessLogic.Services;
using SLNDotNetCore.NLayer.DataAccess.Models;
BL_Blog bl_blog = new BL_Blog();
IEnumerable<BlogModel> model = bl_blog.GetBlogs();
foreach (var item in model)
{
    Console.WriteLine($"BlogId: {item.BlogId}");
    Console.WriteLine($"BlogTitle: {item.BlogTitle}");
    Console.WriteLine($"BlogAuthor: {item.BlogAuthor}"); 
    Console.WriteLine($"BlogContent: {item.BlogContent}");
    Console.WriteLine("****************************\r\n");

}

