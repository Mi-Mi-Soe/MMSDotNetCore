using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MMSDotNetCore.RestApi.Models;
using System.Data;

namespace MMSDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_blog";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            BlogModel item = FindById(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            blog.BlogId = id;
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId=@BlogId";
            var result = db.Execute(query, blog);
            string message = result > 0 ? "Blog update successful" : "Blog update fail";
            return Ok(message);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel blog = FindById(id);
            if (blog is null)
            {
                return Ok("No Data Found");
            }
            return Ok(blog);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            BlogModel item = FindById(id);
            if (item is null)
            {
                return Ok("No Data Found");
            }
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if (conditions.Length == 0)
            {
                return NotFound("No Data Found");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogId = id;
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                            SET {conditions} where BlogId = @BlogId";
            var result = db.Execute(query, blog);
            string message = result > 0 ? "Blog update successful" : "Blog update fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel blog = FindById(id);
            if (blog is null)
            {
                return NotFound("No Data Found");
            }
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId=@BlogId";
            var result = db.Execute(query, blog);
            string message = result > 0 ? "Blog delete successful" : "Blog delete fail";
            return Ok(message);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([BlogTitle],
                            [BlogAuthor],
                            [BlogContent])
                            VALUES
                (@BlogTitle,
                @BlogAuthor,
                @BlogContent)";
            var result = db.Execute(query, blog);
            string message = result > 0 ? "New Blog Creation Successful" : "New Blog Creation Fail";
            return Ok(message);
        }

        private BlogModel FindById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId=@BlogId";
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel
            {
                BlogId = id
            }).FirstOrDefault();
            return item;
        }
    }
}
