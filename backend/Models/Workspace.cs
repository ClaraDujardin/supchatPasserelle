using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Workspace
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsPublic { get; set; } = false;

        public ICollection<WorkspaceMembership> WorkspaceMemberships { get; set; } = new List<WorkspaceMembership>();
        public ICollection<Channel> Channels { get; set; } = new List<Channel>();
    }
}
