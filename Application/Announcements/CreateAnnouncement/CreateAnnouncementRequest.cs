namespace Application.Announcements.CreateAnnouncement
{
    public sealed class CreateAnnouncementRequest
    {
        public string Title { get; init; } = null!;
        public string Content { get; init; } = null!;
        public int CourseId { get; init; }
        public int ProfesorId { get; init; }
    }
}
