using DreamGetter.Shared.Abstractions.Repositories;
using EventService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventService.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<MeetingType> MeetingTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
