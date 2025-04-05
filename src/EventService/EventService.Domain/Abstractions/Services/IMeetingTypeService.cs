using EventService.Domain.Entities;

namespace EventService.Domain.Abstractions.Services;

public interface IMeetingTypeService
{
    Task<List<MeetingType>> GetMeetingTypes();
    Task<MeetingType?> GetMeetingTypeById(Guid meetingTypeId);
    Task CreateMeetingType(MeetingType meetingType);
    Task UpdateMeetingType(MeetingType meetingType);
    Task DeleteMeetingTypeById(Guid typeId);
}
