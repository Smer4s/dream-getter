using EventService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventService.Infrastructure.Database.EntityConfigurations;

internal class MeetingTypeConfiguration : IEntityTypeConfiguration<MeetingType>
{
    public void Configure(EntityTypeBuilder<MeetingType> builder)
    {
        builder.ToTable(nameof(MeetingType));
        builder.HasKey(x => x.Id);
    }
}
