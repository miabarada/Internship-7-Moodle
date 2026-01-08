namespace Application.Courses.GetStudentCourses
{
    public sealed class GetStudentCourseRequest
    {
        public int StudentId { get; init; }

        public GetStudentCourseRequest(int studentId) { 
            StudentId = StudentId;
        }
    }
}
