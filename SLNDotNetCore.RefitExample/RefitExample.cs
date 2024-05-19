using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLNDotNetCore.RefitExample
{
    internal class RefitExample
    {
        private readonly IGetBlogs _service = RestService.For<IGetBlogs>("https://localhost:7264");

        public async Task Run()
        {
            await ReadAsync();
            await ReadAsync(1);
            await CreateAsync("refit", "refit", "refit");
            await UpdateAsync(14, "refit", "refit", "refit");
            await DeleteAsync(1);
        }

        private async Task ReadAsync()
        {
            var lst = await _service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine("BlogId is => " + item.BlogId);
                Console.WriteLine("BlogTitle is => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor is => " + item.BlogAuthor);
                Console.WriteLine("BlogContent is => " + item.BlogContent + "\r\n*******************");
            }
        }

        private async Task ReadAsync(int id)
        {
            try
            {
                var item = await _service.GetBlog(id);
                Console.WriteLine("BlogId is => " + item.BlogId);
                Console.WriteLine("BlogTitle is => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor is => " + item.BlogAuthor);
                Console.WriteLine("BlogContent is => " + item.BlogContent);
            }
            catch (ApiException apiex)
            {
                Console.WriteLine(apiex.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task CreateAsync(string title,string author,string content)
        {
            try
            {
                BlogModel blogModel = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                var message = await _service.CreateBlog(blogModel);
                Console.WriteLine(message);
            }
            catch (ApiException apiex)
            {
                Console.WriteLine(apiex.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task UpdateAsync(int id, string title, string author,string content)
        {
            try
            {
                BlogModel blogModel = new BlogModel()
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                var message = await _service.UpdateBlog(id, blogModel);
                Console.WriteLine(message);
            }
            catch (ApiException apiex)
            {
                Console.WriteLine(apiex.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            try
            {
                var message = await _service.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (ApiException apiex)
            {
                Console.WriteLine(apiex.StatusCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
