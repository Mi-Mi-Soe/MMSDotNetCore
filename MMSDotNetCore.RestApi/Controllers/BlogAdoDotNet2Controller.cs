﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MMSDotNetCore.RestApi.Models;
using MMSDotNetCore.Shared;
using System.Data;
using System.Reflection.Metadata;

namespace MMSDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        //private readonly AdoDotNetService _adoDotNetService = 
        //    new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        private readonly AdoDotNetService _adoDotNetService;

        public BlogAdoDotNet2Controller(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();
            //List<BlogModel> lst = new List<BlogModel>();
            //foreach (DataRow item in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel();
            //    blog.BlogId = Convert.ToInt32(item["BlogId"]);
            //    blog.BlogTitle = Convert.ToString(item["BlogTitle"]);
            //    blog.BlogAuthor = Convert.ToString(item["BlogAuthor"]);
            //    blog.BlogContent = Convert.ToString(item["BlogContent"]);
            //    lst.Add(blog);
            //}
            //List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //}).ToList();
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            string query = "select * from Tbl_Blog where BlogId=@BlogId";
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);
            //connection.Close();

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _adoDotNetService.Query<BlogModel>(query,parameters);
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));
            //if (dt.Rows.Count == 0)
            //{
            //    return NotFound("No Data Found");
            //}
            //DataRow dr = dt.Rows[0];
            //var item = new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])

            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                            ([BlogTitle],
                            [BlogAuthor],
                            [BlogContent])
                            VALUES
                (@BlogTitle,
                @BlogAuthor,
                @BlogContent)";
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                                                         new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                                                         new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string message = result > 0 ? "New Blog Creation Successful" : "New Blog Creation Fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId=@BlogId";
            blog.BlogId= id;
            int result = _adoDotNetService.Execute(query,new AdoDotNetParameter("@BlogId",blog.BlogId),
                                                         new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                                                         new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                                                         new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string message = result > 0 ? "Blog update successful" : "Blog update fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId=@BlogId";
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", id));
            string message = result > 0 ? "Blog delete successful" : "Blog delete fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle]=@BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor]=@BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent]=@BlogContent, ";
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            if (conditions.Length == 0)
            {
                return NotFound("No Data Found");
            }
            blog.BlogId = id;
            string query = $@"UPDATE [dbo].[Tbl_Blog]
                            SET {conditions} 
                            WHERE BlogId=@BlogId";
            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogId", blog.BlogId),
                                                         new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                                                         new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                                                         new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            string message = result > 0 ? "Blog update successful" : "Blog update fail";
            return Ok(message);
        }
    }
}
