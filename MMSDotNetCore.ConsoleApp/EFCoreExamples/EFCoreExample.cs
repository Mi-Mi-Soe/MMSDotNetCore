using MMSDotNetCore.ConsoleApp.Dtos;

namespace MMSDotNetCore.ConsoleApp.EFCoreExamples;

public class EFCoreExample
{
    //private readonly AppDbContext db = new AppDbContext();
    private readonly AppDbContext _db;

    public EFCoreExample(AppDbContext db)
    {
        _db = db;
    }

    public void Run()
    {
        Read();
        Edit(2);
        Create("Test Title", "Test Author", "Test Content");
        Update(17, "Test", "Test", "Test");
        Edit(17);
        Delete(17);
    }

    private void Read()
    {
        var lst = _db.Blogs.ToList();
        foreach (BlogDto item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("_________________________________________");
        }
    }

    private void Edit(int id)
    {
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
        Console.WriteLine($"BlogId {id} is successfully edited");
    }

    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        _db.Blogs.Add(item);
        var result = _db.SaveChanges();
        string message = result > 0 ? "New Blog Creation Successful" : "New Blog Creation Fail";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }
        item.BlogTitle = title;
        item.BlogAuthor = author;
        item.BlogContent = content;
        int result = _db.SaveChanges();
        string message = result > 0 ? "Blog update successful" : "Blog update fail";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }
        _db.Blogs.Remove(item);
        int result = _db.SaveChanges();
        string message = result > 0 ? "Blog delete successful" : "Blog delete fail";
        Console.WriteLine(message);
    }
}
