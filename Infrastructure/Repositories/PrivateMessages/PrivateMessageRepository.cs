using Domain.Entities;
using Domain.Persistence.PrivateMessages;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PrivateMessages
{
    internal sealed class PrivateMessageRepository : Repository<PrivateMessage, int>, IPrivateMessageRepository
    {
        private readonly AppDbContext _dbContext;

        public PrivateMessageRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add(PrivateMessage privateMessage)
        {
            await _dbContext.PrivateMessages.AddAsync(privateMessage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PrivateMessage>> GetConversation(int User1Id, int User2Id)
        {
            return await _dbContext.PrivateMessages
                .Where(m => (m.SenderId == User1Id ||  m.SenderId == User2Id) && (m.ReceiverId == User1Id || m.ReceiverId == User2Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<PrivateMessage>> GetUserChats(int UserId)
        {
            return await _dbContext.PrivateMessages
                .Where(m => m.SenderId == UserId || m.ReceiverId == UserId)
                .GroupBy(m => m.SenderId == UserId ? m.ReceiverId : m.SenderId)
                .Select(g => g.OrderByDescending(m => m.SentAt).First())
                .OrderByDescending(m => m.SentAt)
                .ToListAsync();
        }
    }
}
