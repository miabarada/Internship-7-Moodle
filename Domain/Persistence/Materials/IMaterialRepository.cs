using Domain.Entities;
using Domain.Persistence.Common;

namespace Domain.Persistence.Materials
{
    public interface IMaterialRepository : IRepository<Material, int>
    {
        Task<IEnumerable<Material>> GetByCourse(int CourseId);

        void Add(Material material);
    }
}
