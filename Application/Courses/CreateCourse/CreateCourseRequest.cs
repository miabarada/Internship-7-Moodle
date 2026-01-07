namespace Application.Courses.CreateCourse
{
    public sealed class CreateCourseRequest
    {
        public string Name { get; init; } = null!;
        public int ProfesorId { get; init; }
    }
}
