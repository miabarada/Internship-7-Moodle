using Domain.Entities;
using Domain.Persistence.Materials;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Materials
{
    internal sealed class MaterialRepository : Repository<Material, int>, IMaterialRepository
    {
        private readonly AppDbContext _dbContext;

        public MaterialRepository(AppDbContext dbContext)

            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add(Material material)
        {
            await _dbContext.Materials.AddAsync(material);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Material>> GetByCourse(int id)
        {
            return await _dbContext.Materials
                .Where(c => c.CourseId == id)
                .ToListAsync();
        }
    }
}
