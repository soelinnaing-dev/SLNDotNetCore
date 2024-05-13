// See https://aka.ms/new-console-template for more information
using RestSharp;
using SLNDotNetCore.ConsoleAppRestClientExample;

Console.WriteLine("This is RestClient Example\r\n");
RestClientExample restClientExample = new RestClientExample();
await restClientExample.Run();
Console.ReadKey();
