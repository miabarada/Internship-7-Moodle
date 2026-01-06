using Domain.Persistence.Materials;
using Domain.Persistence.PrivateMessages;
using Infrastructure.Database;

namespace Infrastructure.Repositories.PrivateMessages
{
    public class PrivateMessageUnitOfWork : IPrivateMessageUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IPrivateMessageRepository Repository { get; }

        public PrivateMessageUnitOfWork(AppDbContext dbContext, IPrivateMessageRepository repository)
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
