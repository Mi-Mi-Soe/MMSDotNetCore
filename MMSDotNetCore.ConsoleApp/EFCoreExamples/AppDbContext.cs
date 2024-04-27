using Microsoft.EntityFrameworkCore;
using MMSDotNetCore.ConsoleApp.Dtos;
using MMSDotNetCore.ConsoleApp.Services;

namespace MMSDotNetCore.ConsoleApp.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
