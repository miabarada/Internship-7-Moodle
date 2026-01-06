using Domain.Entities;
using Domain.Persistence.Common;

namespace Domain.Persistence.Enrollments
{
    public interface IEnrollmentRepository : IRepository<Enrollment, int>
    {
        Task<bool> Exists(int StudentId, int CourseId);

        Task<IEnumerable<Enrollment>> GetByCourse(int CourseId);
        Task<IEnumerable<Enrollment>> GetByStudent(int StudentId);

        void Add(Enrollment enrollment);
        void Remove(Enrollment enrollment);
    }
}
