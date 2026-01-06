namespace Domain.Entities
{
    public class PrivateMessage
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; } = null!;

        public int ReceiverId { get; set; }
        public User Receiver { get; set; } = null!;

        public String Content { get; set; } = null!;
        public DateTime SentAt { get; set; }
    }
}
