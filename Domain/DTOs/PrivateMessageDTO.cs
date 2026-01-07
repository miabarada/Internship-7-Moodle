namespace Domain.DTOs
{
    public class PrivateMessageDTO
    {
        public int Id { get; init; }
        public int SenderId { get; init; }
        public int ReceiverId { get; init; }
        public DateTime SentAt { get; init; }
        public string Content { get; set; } = null!;
    }
}
