using System;

namespace Backend.Models
{
    public class WorkspaceMembership
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid WorkspaceId { get; set; }
        public Workspace Workspace { get; set; } = null!;

        public string Role { get; set; } = "Member"; // "Admin", "Member", "Guest"
    }
}
