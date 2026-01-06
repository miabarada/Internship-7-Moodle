using Domain.Persistence.Announcements;
using Domain.Persistence.Courses;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Announcements
{
    public class AnnouncementUnitOfWork : IAnnouncementUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public IAnnouncementRepository Repository { get; }

        public AnnouncementUnitOfWork(AppDbContext dbContext, IAnnouncementRepository repository)
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
