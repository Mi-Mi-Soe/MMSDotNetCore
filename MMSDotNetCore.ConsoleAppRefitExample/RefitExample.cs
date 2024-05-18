using Refit;

namespace MMSDotNetCore.ConsoleAppRefitExample
{
    public class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7216");

        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(0);
            //await CreateBlog("Lisa", "Yaya", "Rash Mika");
            //await PutBlog(117, "Lisa", "Yaya", "Rash Mika");
            await DeleteBlog(120);
        }

        private async Task ReadAsync()
        {
            var lst = await _service.GetBlog();
            foreach (var item in lst)
            {
                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
                Console.WriteLine("---------------------------------------");
            }
        }

        private async Task EditAsync(int id)
        {
            try
            {
                var item = await _service.EditBlog(id);
                Console.WriteLine("BlogId => " + item.BlogId);
                Console.WriteLine("BlogTitle => " + item.BlogTitle);
                Console.WriteLine("BlogAuthor => " + item.BlogAuthor);
                Console.WriteLine("BlogContent => " + item.BlogContent);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task CreateBlog(string title, string author, string content)
        {
            BlogModel blog = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var result = await _service.CreateBlog(blog);
            Console.WriteLine(result);
        }

        public async Task PutBlog(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                var result = await _service.PutBlog(id, blog);
                Console.WriteLine(result);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task DeleteBlog(int id)
        {
            try
            {
                var result = await _service.DeleteBlog(id);
                Console.WriteLine(result);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
