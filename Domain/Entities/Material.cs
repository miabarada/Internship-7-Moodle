namespace Domain.Entities
{
    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;

        public DateTime CreatedAt {  get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!; 
    }
}
