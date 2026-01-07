using Application.Common.Model;
using Domain.Common.Validation;
using Domain.DTOs;
using Domain.Persistence.Courses;
namespace Application.Courses.GetCourseById
{
    public sealed class GetCourseByIdRequestHandler : RequestHandler<GetCourseByIdRequest, CourseDTO>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdRequestHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        protected override async Task<Result<CourseDTO>> HandleRequestAsync(GetCourseByIdRequest request, Result<CourseDTO> result)
        {
            var course = await _courseRepository.GetById(request.Id);

            if (course == null)
            {
                result.SetValidationResult(ValidationResult.Error("COURSE_NOT FOUND", "kolegij ne postoji"));
                return result;
            }

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
