using EventService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Database.EntityConfigurations;

internal class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
{
    public void Configure(EntityTypeBuilder<Meeting> builder)
    {
        builder.ToTable(nameof(Meeting));
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Type)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);
    }
}
