namespace Backend.DTOs
{
    public class FileUploadResponseDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public long Size { get; set; }
        public string MimeType { get; set; } = null!;
        public Guid MessageId { get; set; }
    }
}
