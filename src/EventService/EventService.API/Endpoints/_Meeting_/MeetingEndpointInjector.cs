namespace EventService.API.Endpoints._Meeting_;

internal static class MeetingEndpointInjector
{
    public static void AddMeetingTypeEndpoints(this WebApplication app)
    {
        var meetingGroup = app.MapGroup("/meeting").WithTags("Meetings");

        meetingGroup.MapGet("/list", GetMeetingsRequest.Request);
        meetingGroup.MapGet("{meetingId:guid}", GetMeetingRequest.Request);
        meetingGroup.MapPost("", CreateMeetingRequest.Request);
        meetingGroup.MapPut("", UpdateMeetingRequest.Request);
        meetingGroup.MapDelete("{meetingId:guid}", DeleteMeetingRequest.Request);
    }
}
