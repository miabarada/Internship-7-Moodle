namespace Domain.Entities
{
    public class Material
    {
        public int Id { get; set; }

        public String Name { get; set; } = null!;
        public String Url { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public int ProfessorId { get; set; }
        public User Professor { get; set; } = null!;
    }
}
