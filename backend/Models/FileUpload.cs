using System;

namespace Backend.Models
{
    public class FileUpload
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public long Size { get; set; } // Taille en octets
        public string MimeType { get; set; } = null!; // Ex: "image/png"

        public Guid MessageId { get; set; }
        public Message Message { get; set; } = null!;
    }
}
