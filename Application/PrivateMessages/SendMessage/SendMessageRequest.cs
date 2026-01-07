namespace Application.PrivateMessages.SendMessage
{
    public class SendMessageRequest
    {
        public int SenderId { get; init; }
        public int RecieverId { get; init; }
        public string Content { get; init; } = null!;
    }
}
