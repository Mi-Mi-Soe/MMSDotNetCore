using Microsoft.EntityFrameworkCore;
using MinimalApi.Db;
namespace MinimalApi.Features
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder MapBlog(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapGet("/api/blog/{id}", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null) return Results.Ok("No Data Found");
                return Results.Ok(item);
            });

            app.MapPost("/api/blog", async (AppDbContext db, BlogModel blog) =>
            {
                await db.Blogs.AddAsync(blog);
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Blog Creation Successful." : "Blog Creation Fail";
                return Results.Ok(message);
            });

            app.MapPut("/api/blog/{id}", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = await db.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null) return Results.Ok("No Data Found");
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                db.Blogs.Update(item);
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Blog Update Successful." : "Blog Update Fail";
                return Results.Ok(message);
            });

            app.MapDelete("/api/blog/{id}", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.AsNoTracking()
               .FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null) return Results.Ok("No Data Found");
                db.Blogs.Remove(item);
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Blog Deletion Successful." : "Blog Deletion Fail";
                return Results.Ok(message);
            });
            return app;
        }
    }
}
