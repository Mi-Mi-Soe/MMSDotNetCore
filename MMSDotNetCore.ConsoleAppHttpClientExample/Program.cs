// See https://aka.ms/new-console-template for more information
using MMSDotNetCore.ConsoleAppHttpClientExample;
using Newtonsoft.Json;
using System.Security.Claims;

Console.WriteLine("Hello, World!");

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7270/api/blog");

//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr);
//    foreach(var item in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(item));
//        Console.WriteLine($"Title => {item.BlogTitle}");
//        Console.WriteLine($"Author => {item.BlogAuthor}");
//        Console.WriteLine($"Content => {item.BlogContent}");
//    }
//}

HttpClientExample clientExample = new HttpClientExample();
 await clientExample.Run();
Console.ReadLine();

