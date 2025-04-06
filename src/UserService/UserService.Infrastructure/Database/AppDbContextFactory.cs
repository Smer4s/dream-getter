using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DreamGetter.Shared.Utils;

namespace UserService.Infrastructure.Database
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(args[0]);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}