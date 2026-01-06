using Domain.Persistence.Materials;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Materials
{
    public class MaterialUnitOfWork : IMaterialUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IMaterialRepository Repository { get; }

        public MaterialUnitOfWork(AppDbContext dbContext, IMaterialRepository repository)
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
