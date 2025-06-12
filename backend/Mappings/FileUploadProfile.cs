using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Mappings
{
    public class FileUploadProfile : Profile
    {
        public FileUploadProfile()
        {
            CreateMap<FileUpload, FileUploadResponseDto>();
        }
    }
}
