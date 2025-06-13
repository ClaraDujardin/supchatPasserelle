using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? ProfilePictureUrl { get; set; }

        public ICollection<WorkspaceMembership> WorkspaceMemberships { get; set; } = new List<WorkspaceMembership>();
        public ICollection<ChannelMembership> ChannelMemberships { get; set; } = new List<ChannelMembership>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
