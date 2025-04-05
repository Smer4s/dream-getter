using DreamGetter.Shared.Abstractions.Entities;

namespace EventService.Domain.Entities;

public class MeetingType : Entity
{
    public string Title { get; set; } = null!;
}
