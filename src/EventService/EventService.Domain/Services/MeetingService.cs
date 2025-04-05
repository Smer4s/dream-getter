using EventService.Domain.Abstractions.Repositories;
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;

namespace EventService.Domain.Services;

internal class MeetingService(IMeetingRepository meetingRepository) : IMeetingService
{
    public async Task<List<Meeting>> GetMeetings()
    {
        var meetings = await meetingRepository.GetAll();

        return meetings;
    }
}
