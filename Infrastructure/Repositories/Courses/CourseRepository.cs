using Domain.Entities;
using Domain.Persistence.Courses;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Courses
{
    internal sealed class CourseRepository : Repository<Course, int>, ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Course>> GetByProfessor(int id)
        {
            return await _dbContext.Courses
                .Where(c => c.ProfessorId == id)
                .ToListAsync();
        }
    }
}
