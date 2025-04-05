using DreamGetter.Shared.Abstractions.Repositories;
using EventService.Domain.Abstractions.Repositories;
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;

namespace EventService.Domain.Services;

internal class MeetingService(IMeetingRepository meetingRepository, IUnitOfWork unitOfWork) : IMeetingService
{
    public Task CreateMeeting(Meeting meeting)
    {
        meetingRepository.Create(meeting);

        return unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteMeetingById(Guid meetingId)
    {
        var meeting = await GetMeetingById(meetingId);
        if (meeting == null)
        {
            throw new ArgumentNullException(nameof(meeting));
        }

        meetingRepository.Delete(meeting);

        await unitOfWork.SaveChangesAsync();
    }

    public Task<Meeting?> GetMeetingById(Guid meetingId)
        => meetingRepository.GetById(meetingId);

    public async Task<List<Meeting>> GetMeetings()
    {
        var meetings = await meetingRepository.GetAll();

        return meetings;
    }

    public Task UpdateMeeting(Meeting meeting)
    {
        meetingRepository.Update(meeting);

        return unitOfWork.SaveChangesAsync();
    }
}
