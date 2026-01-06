using Domain.Entities;
using Domain.Persistence.Common;

namespace Domain.Persistence.PrivateMessages
{
    public interface IPrivateMessageRepository : IRepository<PrivateMessage, int>
    {
        Task<IEnumerable<PrivateMessage>> GetConversation(int User1Id, int User2Id);
        Task<IEnumerable<PrivateMessage>> GetUserChats(int UserID);

        void Add(PrivateMessage privateMessage);
    }
}
