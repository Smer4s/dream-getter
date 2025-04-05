using DreamGetter.Shared.Abstractions.Repositories;
using EventService.Domain.Abstractions.Repositories;
using EventService.Domain.Abstractions.Services;
using EventService.Domain.Entities;


namespace EventService.Domain.Services
{
    internal class MeetingTypeService(IMeetingTypeRepository meetingTypeRepository, IUnitOfWork unitOfWork) : IMeetingTypeService
    {
        public Task CreateMeetingType(MeetingType meetingType)
        {
            meetingTypeRepository.Create(meetingType);

            return unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMeetingTypeById(Guid typeId)
        {
            var meeting = await GetMeetingTypeById(typeId);
            if (meeting == null)
            {
                throw new ArgumentException(nameof(meeting));
            }

            await unitOfWork.SaveChangesAsync();
        }

        public Task<MeetingType?> GetMeetingTypeById(Guid meetingTypeId)
            => meetingTypeRepository.GetById(meetingTypeId);

        public Task<List<MeetingType>> GetMeetingTypes()
        {
            return meetingTypeRepository.GetAll();
        }

        public Task UpdateMeetingType(MeetingType meetingType)
        {
            meetingTypeRepository.Update(meetingType);

            return unitOfWork.SaveChangesAsync();
        }
    }
}
