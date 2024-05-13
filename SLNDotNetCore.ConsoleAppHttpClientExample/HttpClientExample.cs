using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SLNDotNetCore.ConsoleAppHttpClientExample
{
    internal class HttpClientExample
    {
        HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7264") };
        string _endPoint = "api/EFCoreBlog";

        public async Task Run()
        {
            await ReadAsync();
            await Readasync(14);
            await Readasync(200);
            await Deleteasync(1);
            await Deleteasync(10);
            await CreateAsync("httptitle", "httpauthor", "httpcontent");
            await UpdateAsync(9, "httpUpdateTitle", "httpUpdateAuthor", "httpUpdateContent");
            await PatchAsync(9, "httpPatchTitle");
        }

        private async Task ReadAsync()
        {
            var response = await _client.GetAsync(_endPoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonString)!;
                foreach (var item in lst)
                {
                    Console.WriteLine($"BlogId =>{JsonConvert.SerializeObject(item.BlogId)}");
                    Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
                    Console.WriteLine($"BlogAuthor =>{JsonConvert.SerializeObject(item.BlogAuthor)}");
                    Console.WriteLine($"BlogContent =>{JsonConvert.SerializeObject(item.BlogContent)}");
                    Console.WriteLine("*****************************\r\n");
                }
            }
        }

        private async Task Readasync(int id)
        {
            var response = await _client.GetAsync($"{_endPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonString)!;
                Console.WriteLine("This is ReadAsyncs With Id\r\n");
                Console.WriteLine("##########################");
                Console.WriteLine($"BlogId =>{JsonConvert.SerializeObject(item.BlogId)}");
                Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
                Console.WriteLine($"BlogAuthor =>{JsonConvert.SerializeObject(item.BlogAuthor)}");
                Console.WriteLine($"BlogContent =>{JsonConvert.SerializeObject(item.BlogContent)}");
                Console.WriteLine("*****************************\r\n");
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message + "\r\n");
            }
        }

        private async Task Deleteasync(int id)
        {
            Console.WriteLine("This is Delete");
            Console.WriteLine("###############");
            var response = await _client.DeleteAsync($"{_endPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel model = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string jsonString = JsonConvert.SerializeObject(model);
            HttpContent paraContent = new StringContent(jsonString, Encoding.UTF8, Application.Json);

            var response = await _client.PostAsync(_endPoint, paraContent);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel model = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string jsonString = JsonConvert.SerializeObject(model);
            HttpContent paraContent = new StringContent(jsonString, Encoding.UTF8, Application.Json);

            var response = await _client.PutAsync($"{_endPoint}/{id}", paraContent);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task PatchAsync(int id, params string[]paraBlog)
        {
            BlogModel model = new BlogModel();
            if (paraBlog.Length >= 1)
            {
                model.BlogTitle = paraBlog[0];

                if (paraBlog.Length >= 2)
                {
                    model.BlogAuthor = paraBlog[1];

                    if (paraBlog.Length >= 3)
                    {
                        model.BlogContent = paraBlog[2];
                    }
                }
            }
            string jsonString = JsonConvert.SerializeObject(model);
            HttpContent paraContent = new StringContent(jsonString, Encoding.UTF8, Application.Json);

            var response = await _client.PatchAsync($"{_endPoint}/{id}", paraContent);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
