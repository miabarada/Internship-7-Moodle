using Application.Common.Model;
using Domain.DTOs;
using Domain.Persistence.Courses;

namespace Application.Courses.GetProfesorCourses
{
    public sealed class GetProfesorCourseRequestHandler : RequestHandler<GetProfesorCourseRequest, List<CourseDTO>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetProfesorCourseRequestHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        protected override async Task<Result<List<CourseDTO>>> HandleRequestAsync(GetProfesorCourseRequest request, Result<List<CourseDTO>> result)
        {
            var courses = await _courseRepository.GetByProfessor(request.ProfesorId);

            result.SetResult(courses.Select(c => new CourseDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList()
            );

            return result;
        }
    }
}
