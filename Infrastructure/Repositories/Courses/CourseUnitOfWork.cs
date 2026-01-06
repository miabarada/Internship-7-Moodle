using Domain.Persistence.Courses;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Courses
{
    public class CourseUnitOfWork : ICourseUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public ICourseRepository Repository { get; }

        public CourseUnitOfWork(AppDbContext dbContext, ICourseRepository repository)
        {
            _dbContext = dbContext;
            Repository = repository;
        }

        public async Task CreateTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
