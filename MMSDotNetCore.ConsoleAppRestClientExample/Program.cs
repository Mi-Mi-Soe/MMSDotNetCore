// See https://aka.ms/new-console-template for more information
using MMSDotNetCore.ConsoleAppRestClientExample;

Console.WriteLine("Hello, World!");
RestClientExample restClientExample = new RestClientExample();
await restClientExample.Run();
Console.ReadLine();
