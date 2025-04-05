using DreamGetter.Shared.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
