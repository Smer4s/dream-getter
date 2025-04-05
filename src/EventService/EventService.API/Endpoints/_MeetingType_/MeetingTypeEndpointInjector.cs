namespace EventService.API.Endpoints._MeetingType_;

internal static class MeetingTypeEndpointInjector
{
    public static void AddMeetingEndpoints(this WebApplication app)
    {
        var meetingGroup = app.MapGroup("/meetingType").WithTags("MeetingTypes");

        meetingGroup.MapGet("/list", GetMeetingTypesRequest.Request);
        meetingGroup.MapGet("{meetingTypeId:guid}", GetMeetingTypeRequest.Request);
        meetingGroup.MapPost("", CreateMeetingTypeRequest.Request);
        meetingGroup.MapPut("", UpdateMeetingTypeRequest.Request);
        meetingGroup.MapDelete("{meetingTypeId:guid}", DeleteMeetingTypeRequest.Request);
    }
}
