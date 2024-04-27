using Dapper;
using Microsoft.Data.SqlClient;
using MMSDotNetCore.ConsoleApp.Dtos;
using MMSDotNetCore.ConsoleApp.Services;
using System.Data;

namespace MMSDotNetCore.ConsoleApp.DapperExamples;

internal class DapperExample
{
    public void Run()
    {
        Read();
        //Edit(2);
        //Create("Test Title", "Test Author", "Test Content");
        //Update(2, "Test", "Test", "Test");
        Edit(2);
        Delete(2);
    }

    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>("select * from Tbl_Blog").ToList();
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
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        var item = db.Query("select * from Tbl_Blog where BlogId=@BlogId", new BlogDto
        {
            BlogId = id
        }).FirstOrDefault();
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
        BlogDto blogData = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([BlogTitle],
                            [BlogAuthor],
                            [BlogContent])
                            VALUES
                (@BlogTitle,
                @BlogAuthor,
                @BlogContent)";
        var result = db.Execute(query, blogData);
        string message = result > 0 ? "New Blog Creation Successful" : "New Blog Creation Fail";
        Console.WriteLine(message);
    }

    private void Update(int id, string title, string author, string content)
    {
        BlogDto blogData = new BlogDto()
        {
            BlogId = id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId=@BlogId";
        var result = db.Execute(query, blogData);
        string message = result > 0 ? "Blog update successful" : "Blog update fail";
        Console.WriteLine(message);
    }

    private void Delete(int id)
    {
        BlogDto blogData = new BlogDto()
        {
            BlogId = id,
        };
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId=@BlogId";
        var result = db.Execute(query, blogData);
        string message = result > 0 ? "Blog delete successful" : "Blog delete fail";
        Console.WriteLine(message);
    }
}
