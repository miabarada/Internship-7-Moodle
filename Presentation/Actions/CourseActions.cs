using Application.Announcements.CreateAnnouncement;
using Application.Common;
using Application.Courses.EnrollStudent;
using Application.Courses.GetCourseById;
using Application.Courses.GetProfesorCourses;
using Application.Courses.GetStudentCourses;
using Application.Materials.CreateMaterial;

namespace Presentation.Actions
{
    public class CourseActions
    {
        public readonly GetStudentCourseRequestHandler _getStudentCourseRequestHandler;
        public readonly GetProfesorCourseRequestHandler _getProfesorCourseRequestHandler;
        private readonly CreateAnnouncementRequestHandler _createAnnouncementRequestHandler;
        private readonly CreateMaterialRequestHandler _createMaterialRequestHandler;
        private readonly GetCourseByIdRequestHandler _getCourseByIdRequestHandler;
        private readonly EnrollStudentRequestHandler _enrollStudentRequestHandler;
        public CourseActions(GetStudentCourseRequestHandler getStudentCourseRequestHandler, GetProfesorCourseRequestHandler getProfesorCourseRequestHandler, CreateAnnouncementRequestHandler createAnnouncementRequestHandler, CreateMaterialRequestHandler createMaterialRequestHandler, GetCourseByIdRequestHandler getCourseByIdRequestHandler, EnrollStudentRequestHandler enrollStudentRequestHandler)
        {
            _getStudentCourseRequestHandler = getStudentCourseRequestHandler;
            _getProfesorCourseRequestHandler = getProfesorCourseRequestHandler;
            _createAnnouncementRequestHandler = createAnnouncementRequestHandler;
            _createMaterialRequestHandler = createMaterialRequestHandler;
            _getCourseByIdRequestHandler = getCourseByIdRequestHandler;
            _enrollStudentRequestHandler = enrollStudentRequestHandler;
        }

        public async Task<IEnumerable<CourseResponse>> GetStudentCoursesAsync(int StudentId)
        {
            var result = await _getStudentCourseRequestHandler.ProcessAuthorizedRequestAsync(new GetStudentCourseRequest(StudentId));

            if (result == null)
            {
                return new List<CourseResponse>();
            }

            return result.Value.Select(x => new CourseResponse
            {
                Id = x.CourseId,
                Name = x.Name,
                ProfessorId = x.ProfesorId
            }).ToList();
        }
    }
}
