using Application.Common.Model;
using Domain.DTOs;
using Domain.Persistence.PrivateMessages;

namespace Application.PrivateMessages.GetChat
{
    public class GetChatRequestHandler : RequestHandler<GetChatRequest, List<PrivateMessageDTO>>
    {
        private readonly IPrivateMessageRepository _privateMessageRepository;

        public GetChatRequestHandler(IPrivateMessageRepository privateMessageRepository)
        {
            _privateMessageRepository = privateMessageRepository;
        }

        protected override async Task<Result<List<PrivateMessageDTO>>> HandleRequestAsync(GetChatRequest request, Result<List<PrivateMessageDTO>> result)
        {
            var messages = await _privateMessageRepository.GetConversation(request.User1ID, request.User2ID);

            result.SetResult(messages.OrderBy(m => m.SentAt).Select(m => new PrivateMessageDTO
            {
                Id = m.Id,
                SenderId = m.SenderId,
                ReceiverId = m.ReceiverId,
                Content = m.Content,
                SentAt = m.SentAt
            }).ToList());

            return result;
        }
    }
}
