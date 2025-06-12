namespace Backend.DTOs
{
    public class ChannelResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsPrivate { get; set; }
        public Guid WorkspaceId { get; set; }
    }

    public class CreateChannelDto
    {
        public string Name { get; set; } = null!;
        public bool IsPrivate { get; set; } = false;
        public Guid WorkspaceId { get; set; }
    }

    public class AddChannelMemberDto
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = "Member";
    }
}
