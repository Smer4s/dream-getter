using EventService.Domain.Entities.Abstractions;

namespace EventService.Domain.Entities;

public class MeetingType : Entity
{
    public string Title { get; set; } = null!;
}
