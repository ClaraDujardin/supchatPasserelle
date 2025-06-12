using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Channel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsPrivate { get; set; } = false;

        public Guid WorkspaceId { get; set; }
        public Workspace Workspace { get; set; } = null!;

        public ICollection<ChannelMembership> ChannelMemberships { get; set; } = new List<ChannelMembership>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
