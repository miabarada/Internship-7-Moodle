namespace Application.Courses.EnrollStudent
{
    public sealed class EnrollStudentRequest
    {
        public int StudentId { get; init; }
        public int CourseId { get; init; }
        public int ProfesorId { get; init; }
    }
}
