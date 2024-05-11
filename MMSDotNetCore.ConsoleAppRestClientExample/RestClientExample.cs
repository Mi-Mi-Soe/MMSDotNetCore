using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using RestSharp;

namespace MMSDotNetCore.ConsoleAppRestClientExample
{
    public class RestClientExample
    {
        private readonly RestClient _restClient = new RestClient(new Uri("https://localhost:7270"));

        private readonly string _blogEndpoint = "api/blog";

        public async Task Run()
        {
            //  await ReadAsync();
            // await EditAsync(119);
            //  await DeleteAsync(119);
            //  await CreateAsync("Ice Cream", "Coconut", "Mango");
            await UpdateAsync(121, "Ice Cream", "Coconut", "Mango");
        }

        private async Task ReadAsync()
        {
            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
            var response = await _restClient.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content;
                Console.WriteLine(jsonStr);
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr);
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Content => {item.BlogContent}");
                }
            }
        }

        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync(restRequest);


            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content;
                Console.WriteLine(jsonStr);
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr);

                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
            else
            {
                string message = response.Content;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content;
                Console.WriteLine(message);
            }
        }

        public async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Post);
            restRequest.AddJsonBody(blog);
            var response = await _restClient.ExecuteAsync(restRequest);
            string message = response.Content;
            Console.WriteLine(message);
        }

        public async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blog);
            var response = await _restClient.ExecuteAsync(restRequest);

            string message = response.Content;
            Console.WriteLine(message);
        }
    }
}
