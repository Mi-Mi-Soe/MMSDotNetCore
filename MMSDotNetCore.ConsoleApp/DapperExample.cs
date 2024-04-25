using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MMSDotNetCore.ConsoleApp;

internal class DapperExample
{
    public void Run()
    {
        Read();
        Edit(2);
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
}
