namespace Backend.DTOs
{
    public class MessageResponseDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid UserId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateMessageDto
    {
        public string Content { get; set; } = null!;
        public Guid ChannelId { get; set; }
    }
}
