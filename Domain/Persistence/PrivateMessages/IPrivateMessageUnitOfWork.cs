using Domain.Persistence.Common;

namespace Domain.Persistence.PrivateMessages
{
    public interface IPrivateMessageUnitOfWork : IUnitOfWork
    {
        IPrivateMessageRepository Repository { get; }
    }
}
