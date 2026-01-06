using Domain.Entities;
using Domain.Persistence.Enrollments;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories.Enrollments
{
    internal sealed class EnrollmentRepository : Repository<Enrollment, int>, IEnrollmentRepository
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

        public Task<IEnumerable<Enrollment>> GetByCourse(int CourseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Enrollment>> GetByStudent(int StudentId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Enrollment enrollment)
        {
            _dbContext.Enrollments.Remove(enrollment);
            _dbContext.SaveChangesAsync();
        }
    }
}
