using Microsoft.EntityFrameworkCore;
using MMSDotNetCore.RestApi.Models;

namespace MMSDotNetCore.RestApi.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        //}


        public DbSet<BlogModel> Blogs { get; set; }
    }
}
