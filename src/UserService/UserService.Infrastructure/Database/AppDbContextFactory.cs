using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace UserService.Infrastructure.Database
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    { 
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}