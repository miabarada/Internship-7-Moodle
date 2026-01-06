using Domain.Entities;
using Domain.Persistence.Common;

namespace Domain.Persistence.Announcements
{
    public interface IAnnouncementRepository : IRepository<Announcement, int>
    {
        Task<IEnumerable<Announcement>> GetByCourse(int CourseId);

        void Add(Announcement announcement);
    }
}
