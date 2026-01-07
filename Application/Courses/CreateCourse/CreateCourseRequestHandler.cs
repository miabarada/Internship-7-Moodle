using Application.Common.Model;
using Domain.DTOs;
using Domain.Entities;
using Domain.Persistence.Courses;
using Domain.Persistence.Users;

namespace Application.Courses.CreateCourse
{
    public sealed class CreateCourseRequestHandler : RequestHandler<CreateCourseRequest  , CourseDTO>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CreateCourseRequestHandler(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        protected override async Task<Result<CourseDTO>> HandleRequestAsync(CreateCourseRequest request, Result<CourseDTO> result)
        {
            var profesor = await _userRepository.GetById(request.ProfesorId);

            if (profesor == null || profesor.Role != Domain.Enums.Role.Profesor)
            {
                result.SetValidationResult(Domain.Common.Validation.ValidationResult.Error("PROFESSOR_NOT_FOUND", "Profesor ne postoji."));
                return result;
            }

            var course = new Course
            {
                Name = request.Name,
                ProfessorId = request.ProfesorId
            };

            _courseRepository.Add(course);

            result.SetResult(new CourseDTO
            {
                Id = course.Id,
                Name = course.Name,
                ProfesorId = course.ProfessorId
            });
            return result;
        }
    }
}
