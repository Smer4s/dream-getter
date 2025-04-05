using EventService.Domain.Abstractions.Services;

namespace EventService.API.Endpoints;

internal static class MeetingEndpoints
{
    public static void AddMeetingEndpoints(this WebApplication app)
    {
        app.MapGet("/meetings", (IMeetingService meetingService) =>
        {
            return meetingService.GetMeetings();
        });
    }
}
