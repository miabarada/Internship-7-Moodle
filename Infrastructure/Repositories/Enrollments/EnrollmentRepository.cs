using Domain.Entities;
using Domain.Persistence.Enrollments;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories.Enrollments
{
    public sealed class EnrollmentRepository : Repository<Enrollment, int>, IEnrollmentRepository
    {
        private readonly AppDbContext _dbContext;

        public EnrollmentRepository(AppDbContext dbContext)

            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add(Enrollment enrollment)
        {
            await _dbContext.Enrollments.AddAsync(enrollment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int StudentId, int CourseId)
        {
            return await _dbContext.Enrollments
                .AnyAsync(cs => cs.StudentId == StudentId && cs.CourseId == CourseId);
        }

        public async Task<IEnumerable<Enrollment>> GetByCourse(int CourseId)
        {
            return await _dbContext.Enrollments.Where(e => e.CourseId == CourseId).ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetByStudent(int StudentId)
        {
            return await _dbContext.Enrollments.Where(e => e.StudentId == StudentId).ToListAsync();
        }

        public void Remove(Enrollment enrollment)
        {
            _dbContext.Enrollments.Remove(enrollment);
            _dbContext.SaveChangesAsync();
        }
    }
}
