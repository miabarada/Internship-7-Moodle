using Application.Common.Model;
using Domain.Common.Validation;
using Domain.DTOs;
using Domain.Entities;
using Domain.Persistence.Announcements;
using Domain.Persistence.Courses;
using Domain.Persistence.Users;

namespace Application.Announcements.CreateAnnouncement
{
    public sealed class CreateAnnouncementRequestHandler : RequestHandler<CreateAnnouncementRequest, AnnouncementDTO>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CreateAnnouncementRequestHandler(IAnnouncementRepository announcementRepository, ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _announcementRepository = announcementRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        protected override async Task<Result<AnnouncementDTO>> HandleRequestAsync(CreateAnnouncementRequest request, Result<AnnouncementDTO> result)
        {
            var profesor = await _userRepository.GetById(request.ProfesorId);
            if (profesor == null || profesor.Role != Domain.Enums.Role.Profesor)
            {
                result.SetValidationResult(Domain.Common.Validation.ValidationResult.Error("PROFESSOR_NOT_FOUND", "Profesor ne postoji."));
                return result;
            }

            var course = await _courseRepository.GetById(request.CourseId);
            if (course == null)
            {
                result.SetValidationResult(Domain.Common.Validation.ValidationResult.Error("COURSE_NOT_FOUND", "Kolegij ne postoji."));
                return result;
            }

            if(course.ProfessorId != profesor.Id)
            {
                result.SetValidationResult(ValidationResult.Error("UNAUTHORIZED", "Profesor ne predaje ovaj kolegij."));
                return result;
            }

            var announcement = new Announcement
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow,
                CourseId = request.CourseId,
                ProfessorId = request.ProfesorId
            };

            _announcementRepository.Add(announcement);

            result.SetResult(new AnnouncementDTO
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Content = announcement.Content,
                CreatedAt = announcement.CreatedAt,
                CourseId = announcement.CourseId,
                ProfesorId = announcement.ProfessorId
            });

            return result;
        }
    }
}
