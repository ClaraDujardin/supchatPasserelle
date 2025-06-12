using AutoMapper;
using Backend.Data;
using Backend.DTOs;
using Backend.Hubs;
using Backend.Models;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly INotificationService _notificationService;

        public MessageService(
            ApplicationDbContext context,
            IMapper mapper,
            IHubContext<ChatHub> hubContext,
            INotificationService notificationService)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
            _notificationService = notificationService;
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

            // SignalR : envoyer le message en direct au groupe du canal
            await _hubContext.Clients
                .Group(dto.ChannelId.ToString())
                .SendAsync("ReceiveMessage", new
                {
                    message.Id,
                    message.Content,
                    message.ChannelId,
                    message.UserId,
                    message.CreatedAt
                });

            // Notifier tous les membres du canal sauf l'auteur
            var membres = await _context.ChannelMemberships
                .Where(m => m.ChannelId == dto.ChannelId && m.UserId != userId)
                .ToListAsync();

            foreach (var member in membres)
            {
                await _notificationService.SendAsync(
                    member.UserId,
                    "message",
                    "Nouveau message dans le canal");
            }

            return _mapper.Map<MessageResponseDto>(message);
        }
    }
}
