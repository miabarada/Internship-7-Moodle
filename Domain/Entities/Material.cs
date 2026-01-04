namespace Domain.Entities
{
    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string URL { get; set; } = null!;

        public DateTime Createdat {  get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!; 
    }
}
