using Domain.Persistence.Users;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Users
{
    public  class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IUserRepository Repository { get; }

        public UserUnitOfWork(AppDbContext dbContext, IUserRepository repository)
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
