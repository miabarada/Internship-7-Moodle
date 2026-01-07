using Application.Common.Model;
using Domain.DTOs;
using Domain.Persistence.Announcements;

namespace Application.Announcements.GetCourseAnnouncements
{
    public sealed class GetCourseAnnouncementsRequestHandler : RequestHandler<GetCourseAnnouncementsRequest, List<AnnouncementDTO>>
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public GetCourseAnnouncementsRequestHandler(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        protected override async Task<Result<List<AnnouncementDTO>>> HandleRequestAsync(GetCourseAnnouncementsRequest request, Result<List<AnnouncementDTO>> result)
        {
            var announcements = await _announcementRepository.GetByCourse(request.CourseId);

            result.SetResult(announcements.Select(a => new AnnouncementDTO
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedAt = a.CreatedAt
            }).ToList()
            );

            return result;
        }
    }
}
