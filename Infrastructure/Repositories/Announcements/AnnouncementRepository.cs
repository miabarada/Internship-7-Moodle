using Domain.Entities;
using Domain.Persistence.Announcements;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Announcements
{
    internal sealed class AnnouncementRepository : Repository<Announcement, int>, IAnnouncementRepository
    {
        private readonly AppDbContext _dbContext;

        public AnnouncementRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add(Announcement announcement)
        {
            await _dbContext.Announcements.AddAsync(announcement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Announcement>> GetByCourse(int id)
        {
            return await _dbContext.Announcements
                .Where(c => c.CourseId == id)
                .ToListAsync();
        }
    }
}
