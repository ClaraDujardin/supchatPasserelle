namespace Backend.DTOs
{
    public class WorkspaceResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsPublic { get; set; }
    }

    public class CreateWorkspaceDto
    {
        public string Name { get; set; } = null!;
        public bool IsPublic { get; set; } = false;
    }

    public class AddMemberDto
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = "Member";
    }
}
