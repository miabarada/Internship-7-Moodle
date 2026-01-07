namespace Domain.DTOs
{
    public class ChatDTO
    {
        public int OtherUserId { get; init; }
        public string LastMessageInChat { get; set; } = null!;
        public DateTime LastMessageSentAt { get; set; }
    }
}
