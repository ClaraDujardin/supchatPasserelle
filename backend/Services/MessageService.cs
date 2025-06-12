using AutoMapper;
using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageResponseDto>> GetMessagesByChannelAsync(Guid channelId);
        Task<MessageResponseDto> CreateMessageAsync(CreateMessageDto dto, Guid userId);
    }

    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MessageService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageResponseDto>> GetMessagesByChannelAsync(Guid channelId)
        {
            var messages = await _context.Messages
                .Where(m => m.ChannelId == channelId)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();

            return _mapper.Map<IEnumerable<MessageResponseDto>>(messages);
        }

        public async Task<MessageResponseDto> CreateMessageAsync(CreateMessageDto dto, Guid userId)
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                Content = dto.Content,
                ChannelId = dto.ChannelId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return _mapper.Map<MessageResponseDto>(message);
        }
    }
}
