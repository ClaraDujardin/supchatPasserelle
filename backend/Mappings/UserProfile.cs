using AutoMapper;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); // hash manuellement
        }
    }
}
