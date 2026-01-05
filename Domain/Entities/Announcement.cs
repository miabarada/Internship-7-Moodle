namespace Domain.Entities
{
    public class Announcement
    {
        public int Id { get; set; }

        public String Title { get; set; } = null!;
        public String Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public int ProfessorId { get; set; }
        public User Professor { get; set; } = null!;
    }
}
