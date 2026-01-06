using Domain.Entities;
using Domain.Persistence.Common;

namespace Domain.Persistence.Courses
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        Task<Course?> GetById(int id);

        Task<IEnumerable<Course>> GetAll();
        Task<IEnumerable<Course>> GetByProfessor(int ProfessorId);

        void Add(Course course);
        void Update(Course course);
    }
}
