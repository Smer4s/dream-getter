using DreamGetter.Shared.Abstractions.Entities;

namespace EventService.Domain.Entities;

public class Meeting : Entity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public MeetingType Type { get; set; } = null!;
}
