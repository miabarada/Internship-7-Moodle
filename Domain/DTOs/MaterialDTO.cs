namespace Domain.DTOs
{
    public class MaterialDTO
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public string? Url { get; set; } = null;
        public DateTime CreatedAt { get; set; }
        public int CourseId { get; init; }
        public int ProfesorId { get; init; }
    }
}
