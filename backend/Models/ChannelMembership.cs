using System;

namespace Backend.Models
{
    public class ChannelMembership
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; } = null!;

        public string Role { get; set; } = "Member"; // "Admin", "Member", "Guest"
    }
}
