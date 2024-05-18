using Refit;

namespace MMSDotNetCore.ConsoleAppRefitExample;

public interface IBlogApi
{
    [Get("/api/blog")]
    Task<List<BlogModel>> GetBlog();

    [Get("/api/blog/{id}")]
    Task<BlogModel> EditBlog(int id);

    [Post("/api/blog")]
    Task<string> CreateBlog(BlogModel blog);

    [Put("/api/blog/{id}")]
    Task<string> PutBlog(int id, BlogModel blog);

    [Patch("/api/blog/{id}")]
    Task<string> PatchBlog(int id, BlogModel blog);

    [Delete("/api/blog/{id}")]
    Task<string> DeleteBlog(int id);
}

public class BlogModel
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}
