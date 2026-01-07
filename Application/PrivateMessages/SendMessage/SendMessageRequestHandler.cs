using Application.Common.Model;
using Domain.DTOs;
using Domain.Entities;
using Domain.Persistence.PrivateMessages;

namespace Application.PrivateMessages.SendMessage
{
    public class SendMessageRequestHandler : RequestHandler<SendMessageRequest, PrivateMessageDTO>
    {
        private readonly IPrivateMessageRepository _privateMessageRepository;

        public SendMessageRequestHandler(IPrivateMessageRepository privateMessageRepository)
        {
            _privateMessageRepository = privateMessageRepository;
        }

        protected override async Task<Result<PrivateMessageDTO>> HandleRequestAsync(SendMessageRequest request, Result<PrivateMessageDTO> result)
        {
            var message = new PrivateMessage
            {
                SenderId = request.SenderId,
                ReceiverId = request.RecieverId,
                SentAt = DateTime.UtcNow,
                Content = request.Content
            };

            _privateMessageRepository.Add(message);

            result.SetResult(new PrivateMessageDTO
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ReceiverId = message.ReceiverId,
                SentAt = message.SentAt,
                Content = message.Content
            });

            return result;
        }
    }
}
