using AutoMapper;
using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface IChannelService
    {
        Task<IEnumerable<ChannelResponseDto>> GetAllInWorkspaceAsync(Guid workspaceId);
        Task<ChannelResponseDto> CreateAsync(CreateChannelDto dto, Guid creatorUserId);
        Task<bool> AddMemberAsync(Guid channelId, AddChannelMemberDto dto);
    }

    public class ChannelService : IChannelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ChannelService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChannelResponseDto>> GetAllInWorkspaceAsync(Guid workspaceId)
        {
            var channels = await _context.Channels
                .Where(c => c.WorkspaceId == workspaceId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ChannelResponseDto>>(channels);
        }

        public async Task<ChannelResponseDto> CreateAsync(CreateChannelDto dto, Guid creatorUserId)
        {
            var channel = _mapper.Map<Channel>(dto);
            channel.Id = Guid.NewGuid();

            _context.Channels.Add(channel);

            // Ajouter le créateur comme membre admin du canal
            var membership = new ChannelMembership
            {
                Id = Guid.NewGuid(),
                UserId = creatorUserId,
                ChannelId = channel.Id,
                Role = "Admin"
            };

            _context.ChannelMemberships.Add(membership);
            await _context.SaveChangesAsync();

            return _mapper.Map<ChannelResponseDto>(channel);
        }

        public async Task<bool> AddMemberAsync(Guid channelId, AddChannelMemberDto dto)
        {
            var exists = await _context.ChannelMemberships
                .AnyAsync(m => m.UserId == dto.UserId && m.ChannelId == channelId);

            if (exists) return false;

            var membership = new ChannelMembership
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                ChannelId = channelId,
                Role = dto.Role
            };

            _context.ChannelMemberships.Add(membership);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
