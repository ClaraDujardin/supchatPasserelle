using AutoMapper;
using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IFileUploadService
    {
        Task<FileUploadResponseDto> UploadFileAsync(Guid messageId, IFormFile file);
    }

    public class FileUploadService : IFileUploadService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public FileUploadService(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task<FileUploadResponseDto> UploadFileAsync(Guid messageId, IFormFile file)
        {
            var uploadsDir = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsDir)) Directory.CreateDirectory(uploadsDir);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUpload = new FileUpload
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                FilePath = $"/uploads/{fileName}",
                Size = file.Length,
                MimeType = file.ContentType,
                MessageId = messageId
            };

            _context.FileUploads.Add(fileUpload);
            await _context.SaveChangesAsync();

            return _mapper.Map<FileUploadResponseDto>(fileUpload);
        }
    }
}
