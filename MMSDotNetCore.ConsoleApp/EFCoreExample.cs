namespace MMSDotNetCore.ConsoleApp;

public class EFCoreExample
{
    private readonly AppDbContext db = new AppDbContext();

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
        var lst = db.Blogs.ToList();
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
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
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
        db.Blogs.Add(item);
        var result = db.SaveChanges();
        string message = result > 0 ? "New Blog Creation Successful" : "New Blog Creation Fail";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }
        item.BlogTitle = title;
        item.BlogAuthor = author;
        item.BlogContent = content;
        int result = db.SaveChanges();
        string message = result > 0 ? "Blog update successful" : "Blog update fail";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found.");
            return;
        }
        db.Blogs.Remove(item);
        int result = db.SaveChanges();
        string message = result > 0 ? "Blog delete successful" : "Blog delete fail";
        Console.WriteLine(message);
    }
}
