namespace Application.Materials.CreateMaterial
{
    public class CreateMaterialRequest
    {
        public string Name { get; init; } = null!;
        public string Url { get; init; } = null!;
        public int CourseId { get; init; }
        public int ProfesorId { get; init; }
    }
}
