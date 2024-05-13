using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SLNDotNetCore.ConsoleAppHttpClientExample;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("This is HTTP Client Example \r\n");
Console.WriteLine("###########################");
//HttpClient client =new HttpClient();
//var response = await client.GetAsync("https://localhost:7264/api/EFCoreBlog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonString = await response.Content.ReadAsStringAsync();
//    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonString)!;
//    foreach(var item in lst)
//    {
//        Console.WriteLine($"BlogId =>{JsonConvert.SerializeObject(item.BlogId)}");
//        Console.WriteLine($"BlogTitle => {JsonConvert.SerializeObject(item.BlogTitle)}");
//        Console.WriteLine($"BlogAuthor =>{JsonConvert.SerializeObject(item.BlogAuthor)}");       
//        Console.WriteLine($"BlogContent =>{JsonConvert.SerializeObject(item.BlogContent)}");
//    }
//    Console.ReadKey();
//}
HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.Run();
Console.ReadKey();