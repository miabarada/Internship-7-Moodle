using Application.Common.Model;
using Domain.DTOs;
using Domain.Persistence.Enrollments;

namespace Application.Courses.GetStudentCourses
{
    public sealed class GetStudentCourseRequestHandler : RequestHandler<GetStudentCourseRequest, List<StudentCourseDTO>>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public GetStudentCourseRequestHandler(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        protected override async Task<Result<List<StudentCourseDTO>>> HandleRequestAsync(GetStudentCourseRequest request, Result<List<StudentCourseDTO>> result)
        {
            var courses = await _enrollmentRepository.GetByStudent(request.StudentId);

            result.SetResult(courses.Select(c => new StudentCourseDTO
                {
                    CourseId = c.Id,
                    Name = c.Course.Name,
                    ProfesorId = c.Course.ProfessorId
                }).ToList()
            );

            return result;
        }
    }
}
