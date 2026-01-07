using Application.Common.Model;
using Domain.DTOs;
using Domain.Persistence.PrivateMessages;

namespace Application.PrivateMessages.GetUserChats
{
    public sealed class GetUserChatsRequestHandler : RequestHandler<GetUserChatsRequest, List<ChatDTO>>
    {
        private readonly IPrivateMessageRepository _privateMessagerepository;

        public GetUserChatsRequestHandler(IPrivateMessageRepository privateMessagerepository)
        {
            _privateMessagerepository = privateMessagerepository;
        }

        protected override async Task<Result<List<ChatDTO>>> HandleRequestAsync(GetUserChatsRequest request, Result<List<ChatDTO>> result)
        {
            var messages = await _privateMessagerepository.GetUserChats(request.UserId);

            var chats = messages
                .GroupBy(m => m.SenderId == request.UserId ? m.ReceiverId : m.SenderId)
                .Select(r =>
                {
                    var lastMessage = r.OrderByDescending(m => m.SentAt).First();

                    return new ChatDTO
                    {
                        OtherUserId = r.Key,
                        LastMessageInChat = lastMessage.Content,
                        LastMessageSentAt = lastMessage.SentAt,
                    };
                }).OrderByDescending(c => c.LastMessageSentAt).ToList();

            result.SetResult(chats);

            return result;
        }
    }
}
