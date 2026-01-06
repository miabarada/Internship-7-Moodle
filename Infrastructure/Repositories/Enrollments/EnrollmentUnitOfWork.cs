using Domain.Persistence.Enrollments;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Enrollments
{
    public class EnrollmentUnitOfWork : IEnrollmentUnitOfWOrk
    {
        private readonly AppDbContext _dbContext;
        public IEnrollmentRepository Repository { get; }

        public EnrollmentUnitOfWork(AppDbContext dbContext, IEnrollmentRepository repository)
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
