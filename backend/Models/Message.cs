using System;

namespace Backend.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public FileUpload? FileUpload { get; set; }
    }
}
