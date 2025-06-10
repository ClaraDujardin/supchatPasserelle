using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageResponseDto>();
            CreateMap<CreateMessageDto, Message>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()); // on fixe dans le service
        }
    }
}
